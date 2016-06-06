using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class MediumTankEnemy : TankEnemy
{
	int damage;
	string fullLog;
	public ElementType element;

    void Awake()
    {
        SetMaxHealth(200);
        SetHealth(GetMaxHealth());
        SetSpeed(30);
		damage = 25;
		SetShield (ElementType.NONE);
    }

	public override string DoMove(List<Player> players, List<Enemy> enemies)
	{
		Player target = GetTaunter (players);
		fullLog = "";

		if(target == null)
			target = FindLowestPercentageHealth (players);

		if (GetStatus () == Status.DAZED) {
			PrimaryMove (target);
			SetStatus (Status.NONE);
		} else {
			PrimaryMove (target);
		}
		SetTurnComplete (true);
		return fullLog;
	}

	private void PrimaryMove(Player target)
	{
		target.ReduceHealth (damage, target.GetShield(), element);
		string log = "Damaged " +target.gameObject.name + " for " + damage + " " + ElementAsString(element) + "\n";
		Debug.Log (log);
		fullLog += log;
	}

	private void SpecialMove()
	{
		//will taunt at Hard(?) difficulties, forcing players to attack it. May also gain element damage.
		throw new NotImplementedException();
	}

	// Update is called once per frame
	void Update()
	{

	}
}