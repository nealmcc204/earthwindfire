using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleStrikeM : BasePhysical {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (MediumDamage (), e.GetShield (), AttackElement ());
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Double Strike M";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + MediumDamage() + "of physical damage to two enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}