using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TripleEarthS : BaseEarth {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		foreach (Enemy e in targets) {
			success = e.ReduceHealth (SmallDamage(), e.GetShield(), AttackElement() );
			if (success) {
				e.SetStatus (Status.DAZED);
			}
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		string at = "Triple Earth S";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + SmallDamage() + "of Earth damage to three enemies, and dazes them. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 3;
	}
}