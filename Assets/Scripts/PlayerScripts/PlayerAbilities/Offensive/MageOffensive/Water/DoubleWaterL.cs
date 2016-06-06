using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleWaterL : BaseWater {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (MediumDamage(), e.GetShield(), AttackElement() );
			if (success) {
				e.SetStatus (Status.FROZEN);
			}
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Double Water L";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + LargeDamage() + "of water damage to two enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}