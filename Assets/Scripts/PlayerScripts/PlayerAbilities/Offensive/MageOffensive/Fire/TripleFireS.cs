using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TripleFireS : BaseFire {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (SmallDamage(), e.GetShield(), AttackElement() );
			if (success) {
				e.SetStatus (Status.BURNED);
			}
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Triple Fire S";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + SmallDamage() + "of fire damage to three enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 3;
	}
}