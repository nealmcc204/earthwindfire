using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class EasyHealerEnemy : HealerEnemy
{

	string fullLog;

    void Awake()
    {
        SetMaxHealth(75);
        SetHealth(GetMaxHealth());
        SetSpeed(50);
		SetShield (ElementType.NONE);
    }

	public override string DoMove(List<Player> players, List<Enemy> enemies)
    {
		List<Enemy> targets = new List<Enemy>();
		foreach (Enemy e in enemies) {//checks if enemy is already shielded or if it is dead
			if (!e.GetDead()) {
				targets.Add (e);
			}
		}
		Enemy target = FindLowestPercentageHealth (targets);
		fullLog = "";
		PrimaryMove (target);
		//PlayEffects (ElementType.NONE);
		SetTurnComplete (true);
		return fullLog;
    }

	private void PrimaryMove(Enemy target)
    {
		//Medium difficulty will heal multiple targets.
		int heal = (int)(target.GetMaxHealth() * 0.3);
		target.RestoreHealth(heal);
		string log = "Healed " +target.gameObject.name + " for " + heal + "\n";
		Debug.Log (log);
		fullLog += log;

    }

    private void SpecialMove()
    {
		//This will be a revive and only present in Hard classes.
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}