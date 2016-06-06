using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class HardDamageEnemy : DamageEnemy
{
	int damage;
	string fullLog;
	int cooldown;
	static int maxCooldown;
	public ElementType element;

	void Awake()
	{
		SetMaxHealth(180);
		SetHealth(GetMaxHealth());
		SetSpeed(150);
		SetShield (ElementType.NONE);
		damage = 60;
		maxCooldown = 2;
		cooldown = 0;
	}
		
	public override string DoMove(List<Player> players, List<Enemy> enemies)
	{
		Player target = GetTaunter (players);
		fullLog = "";
		if (target == null) {
			target = FindLowestPercentageHealth (players);
			if (GetStatus () == Status.DAZED) {
				PrimaryMove (target);
				SetStatus (Status.NONE);
			} else {
				if (cooldown <= 0) {
					SpecialMove (players);
					cooldown = maxCooldown;
				} else {
					PrimaryMove (target);
					cooldown--;
				}
			}
		} else {
			PrimaryMove (target);
			cooldown--;
		}
		SetTurnComplete (true);
		return fullLog;
	}

	public void PrimaryMove(Player target)
	{
		bool success = false;
		string log;
		success = target.ReduceHealth (damage, target.GetShield(), element);
		if (success) {
			log = "Damaged " + target.gameObject.name + " for " + damage + " " + ElementAsString(element) + "\n";
			Debug.Log (log);
			fullLog += log;
		} else {
			log = "Attack Blocked \n";
			Debug.Log (log);
			fullLog += log;
		}
	}

	private void SpecialMove(List<Player> targets)
	{
		foreach (Player t in targets) {//changes the element of the character randomly before attacking each target.
			element = RandomElement ();
			PrimaryMove (t);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
