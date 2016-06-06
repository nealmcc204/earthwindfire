using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleEarthShield : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		foreach (Player p in targets) {
			p.SetShield (ElementType.EARTH);
		}
		return true;
	}

	public override string GetAbilityTag()
	{
		return "Double Earth Shield";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Shields two friendly targets against a single Earth attack."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}