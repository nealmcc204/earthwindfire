using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TripleEarthM : BaseEarth {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		success = targets[0].ReduceHealth (MediumDamage(), targets[0].GetShield(), AttackElement() );
		if (success) {
			targets[0].SetStatus (Status.DAZED);
		}
		return success;
	}


	public override string GetAbilityTag()
	{
		string at = "Triple Earth M";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + MediumDamage() + "of Earth damage to three enemies, and dazes them. "; 
		return ad;
	}
		
	public override int GetNumTargets()
	{
		return 3;
	}
}