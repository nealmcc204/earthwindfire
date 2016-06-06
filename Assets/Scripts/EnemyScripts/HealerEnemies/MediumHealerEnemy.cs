using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class MediumHealerEnemy : HealerEnemy
{
	string fullLog;

    void Awake()
    {
        SetMaxHealth(110);
        SetHealth(GetMaxHealth());
        SetSpeed(80);
		SetShield (ElementType.NONE);
    }

	public override string DoMove(List<Player> players, List<Enemy> enemies)
    {
		fullLog = "";
		List<Enemy> targets = new List<Enemy>();
		foreach (Enemy e in enemies) {//checks if enemy is already shielded or if it is dead
			if (!e.GetDead()) {
				targets.Add (e);
			}
		}
		List<Enemy> temp = targets;
		Enemy tempEnemy;
		Enemy target = FindLowestPercentageHealth (temp);
		PrimaryMove (target);
		tempEnemy = target;
		temp.Remove (target);
		target = FindLowestPercentageHealth (temp); //heals 2 different enemies;
		PrimaryMove (target);
		temp.Add (tempEnemy);

		SetTurnComplete (true);
		return fullLog;
    }

	private void PrimaryMove(Enemy target)
    {
		int heal = (int)(target.GetMaxHealth() * 0.3);
		target.RestoreHealth(heal);
		string log = "Healed " +target.gameObject.name + " for " + heal + "\n";
		Debug.Log (log);
		fullLog += log;
    }

    private void SpecialMove()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}