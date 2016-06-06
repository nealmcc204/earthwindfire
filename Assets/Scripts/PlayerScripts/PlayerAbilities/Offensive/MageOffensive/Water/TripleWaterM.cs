using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TripleWaterM : BaseWater {

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
		string at = "Triple Water M";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + MediumDamage() + "of water damage to three enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 3;
	}
}