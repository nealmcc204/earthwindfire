using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleFireShield : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		foreach (Player p in targets) {
			p.SetShield (ElementType.FIRE);
		}
		return true;
	}

	public override string GetAbilityTag()
	{
		return "Double Fire Shield";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Shields two friendly targets against a single Fire attack."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 2;
	}
}