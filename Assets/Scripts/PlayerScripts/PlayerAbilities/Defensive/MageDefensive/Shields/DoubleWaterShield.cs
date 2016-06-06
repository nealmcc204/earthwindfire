using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleWaterShield : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		foreach (Player p in targets) {
			p.SetShield (ElementType.WATER);
		}
		return true;
	}

	public override string GetAbilityTag()
	{
		return "Double Water Shield";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Shields two friendly targets against a single Water attack."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}