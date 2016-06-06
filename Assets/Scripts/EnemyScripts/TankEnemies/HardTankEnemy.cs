using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class HardTankEnemy : TankEnemy
{
	static int maxCooldown;
	int cooldown;
	int damage;
	string fullLog;
	public ElementType element;

    void Awake()
    {
        SetMaxHealth(250);
        SetHealth(GetMaxHealth());
        SetSpeed(30);
		cooldown = 0;
		maxCooldown = 2;
		damage = 35;
		SetShield (ElementType.NONE);
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
					SpecialMove ();
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

	private void PrimaryMove(Player target)
    {
		target.ReduceHealth (damage, target.GetShield(), element);
		string log = "Damaged " + target.gameObject.name + " for " + damage + " " + ElementAsString (element) + "\n";
		Debug.Log (log);
		fullLog += log;
    }

    private void SpecialMove()
    {
		SetTaunt (true);
		fullLog += "Tank is taunting\n";
    }

    // Update is called once per frame
    void Update()
    {

    }
}