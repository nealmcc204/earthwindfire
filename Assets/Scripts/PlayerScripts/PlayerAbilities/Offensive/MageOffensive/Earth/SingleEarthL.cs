using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleEarthL : BaseEarth {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		success = targets[0].ReduceHealth (LargeDamage(), targets[0].GetShield(), AttackElement() );
		if (success) {
			targets[0].SetStatus (Status.DAZED);
		}
		return success;
	}


	public override string GetAbilityTag()
	{
		string at = "Single Earth L";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + LargeDamage() + "of Earth damage to a single enemy, and dazes them. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}
}