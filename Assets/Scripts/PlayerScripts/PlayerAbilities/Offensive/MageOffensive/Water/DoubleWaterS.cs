using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleWaterS : BaseWater {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (SmallDamage(), e.GetShield(), AttackElement() );
			if (success) {
				e.SetStatus (Status.FROZEN);
			}
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Double Water S";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + SmallDamage() + "of water damage to two enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}