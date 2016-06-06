using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class MediumShieldEnemy : ShieldEnemy
{
	public ElementType element;
	string fullLog;
	static int maxCooldown;
	int cooldown;

    void Awake()
    {
        SetMaxHealth(125);
        SetHealth(GetMaxHealth());
        SetSpeed(80);
		cooldown = 0;
		maxCooldown = 2;
		SetShield (ElementType.NONE);
    }

	public override string DoMove(List<Player> players, List<Enemy> enemies)
    {
		fullLog = "";
		List<Enemy> targets = new List<Enemy>();
		foreach (Enemy e in enemies) {//checks if enemy is already shielded or if it is dead
			if (e.GetShield ().GetShieldType () == ElementType.NONE && !e.GetDead()) {
				targets.Add (e);
			}
		}
		if (targets.Count > 0) {
			if (GetStatus () == Status.DAZED || cooldown > 0) {
				Enemy target = FindLowestPercentageHealth (targets);
				PrimaryMove (target);
				cooldown--;
			} else {
				SpecialMove (targets);
				cooldown = maxCooldown;
			}
		} else {
			fullLog = "All Targets Shielded.\n";
		}
		SetTurnComplete (true);
		return fullLog;
    }

	private void PrimaryMove(Enemy target)
    {
		target.SetShield (element);
		string log = "Shielded " +target.gameObject.name + " against " + ElementAsString(element) + "\n";
		Debug.Log (log);
		fullLog += log;
    }

	private void SpecialMove(List<Enemy> enemies)
    {
		List<Enemy> temp = enemies;
		Enemy tempEnemy;
		Enemy target = FindLowestPercentageHealth (temp);
		tempEnemy = target;
		PrimaryMove (target);
		temp.Remove (target);
		target = FindLowestPercentageHealth (temp); //heals 2 different enemies;
		PrimaryMove (target);
		temp.Add(tempEnemy);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
