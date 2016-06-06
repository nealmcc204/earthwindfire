using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class EasyDamageEnemy : DamageEnemy {

	int damage;
	string fullLog;
	ElementType element;

    void Awake()
    {
        SetMaxHealth(100);
        SetHealth(GetMaxHealth());
		SetSpeed(100);
		SetShield (ElementType.NONE);
		damage = 20;
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
		bool success = false;
		string log;
		success = target.ReduceHealth (damage, target.GetShield(), element);
		if (success) {
			log = "Damaged " +target.gameObject.name + " for " + damage + " " + ElementAsString(element) + "\n";
			Debug.Log (log);
			fullLog += log;
		} else {
			log = "AttackBlocked \n";
			Debug.Log (log);
			fullLog += log;
		}
    }

    private void SpecialMove()
    {
		//Medium Enemy Will have special Move, which attacks two players. Hard Enemy will hit both, with a random element.
        throw new NotImplementedException();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
