using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleFireM : BaseFire {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (MediumDamage(), e.GetShield(), AttackElement() );
			if (success) {
				e.SetStatus (Status.BURNED);
			}
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Double Fire M";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + MediumDamage() + "of fire damage to two enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}