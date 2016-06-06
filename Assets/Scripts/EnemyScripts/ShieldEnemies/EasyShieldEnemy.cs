using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class EasyShieldEnemy : ShieldEnemy
{
	public ElementType element;
	string fullLog;

    void Awake()
    {
        SetMaxHealth(100);
        SetHealth(GetMaxHealth());
        SetSpeed(60);
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
		if (targets.Count > 0) {//if there are no valid targets dont do the move
			Enemy target = FindLowestPercentageHealth (targets);
			PrimaryMove (target);
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

    private void SpecialMove()
    {
		//Will shield multiple enemies perhaps in Medium difficulty, then will shield with a randomized element in hard.
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}