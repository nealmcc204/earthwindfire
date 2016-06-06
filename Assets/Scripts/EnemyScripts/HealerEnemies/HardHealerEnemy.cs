using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class HardHealerEnemy : HealerEnemy
{
	int cooldown;
	string fullLog;
	static int maxCooldown;

    void Awake()
    {
        SetMaxHealth(150);
        SetHealth(GetMaxHealth());
        SetSpeed(105);
		maxCooldown = 2;
		cooldown = maxCooldown;
		SetShield (ElementType.NONE);
    }

	public override string DoMove(List<Player> players, List<Enemy> enemies)
	{
		fullLog = "";
		if (GetStatus () == Status.DAZED || cooldown > 0 || !CheckForDeadAllies(enemies)){
			List<Enemy> targets = new List<Enemy>();
			foreach (Enemy e in enemies) {//checks if enemy is already shielded or if it is dead
				if (!e.GetDead()) {
					targets.Add (e);
				}
			}
			List<Enemy> temp = targets;
			Enemy tempEnemy;
			Enemy target = FindLowestPercentageHealth (temp);
			tempEnemy = target;
			PrimaryMove (target);
			temp.Remove (target);
			target = FindLowestPercentageHealth (temp); //heals 2 different enemies;
			PrimaryMove (target);
			temp.Add(tempEnemy);
			cooldown--;
		} else {
			foreach (Enemy e in enemies) {
				if (e.GetDead ()) {
					SpecialMove (e);

					cooldown = maxCooldown;
					SetTurnComplete (true);
					return fullLog;
				}
			}
		}
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


	private void SpecialMove(Enemy target)
    {
		target.SetDead (false);//revives and heals enemy
		string log = "Revived" + target.gameObject.name + "\n";
		Debug.Log (log);
		fullLog += log;
		PrimaryMove (target);
    }

    // Update is called once per frame
    void Update()
    {

    }

	private bool CheckForDeadAllies(List<Enemy> enemies)
	{
		foreach (Enemy e in enemies) {
			if (e.GetDead ())
				return true;
		}
		return false;
	}
}