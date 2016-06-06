using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleFireL : BaseFire {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (LargeDamage(), e.GetShield(), AttackElement() );
			if (success) {
				e.SetStatus (Status.BURNED);
			}
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Double Fire L";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + LargeDamage() + "of fire damage to two enemies. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}