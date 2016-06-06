using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleWaterS : BaseWater {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		success = targets[0].ReduceHealth (SmallDamage(), targets[0].GetShield(), AttackElement() );
		if (success) {
			targets[0].SetStatus (Status.FROZEN);
		}
		return success;
	}


	public override string GetAbilityTag()
	{
		string at = "Single Water S";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + SmallDamage() + "of water damage to a single enemy, and freezes them. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}
}