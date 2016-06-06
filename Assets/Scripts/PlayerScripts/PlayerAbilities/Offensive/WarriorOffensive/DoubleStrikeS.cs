using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleStrikeS : BasePhysical {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (SmallDamage (), e.GetShield (), AttackElement ());
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Double Strike S";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + SmallDamage() + "of physical damage to two enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}