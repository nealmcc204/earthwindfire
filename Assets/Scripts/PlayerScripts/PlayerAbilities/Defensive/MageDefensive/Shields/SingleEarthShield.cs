using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleEarthShield : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		foreach (Player p in targets) {
			p.SetShield (ElementType.EARTH);
		}
		return true;
	}

	public override string GetAbilityTag()
	{
		return "Single Earth Shield";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Shields a single friendly target against a single Earth attack."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}
}