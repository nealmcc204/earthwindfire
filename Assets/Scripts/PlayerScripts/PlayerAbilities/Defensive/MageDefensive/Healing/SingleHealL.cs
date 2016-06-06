using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleHealL : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		bool success = false;
		foreach (Player p in targets) {
			int heal = (int)((p.GetMaxHealth () * (0.5)));
			success = p.RestoreHealth(heal);
		}
		return success;
	}

	public override string GetAbilityTag()
	{
		return "Single Heal L";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Heals a single friendly target for 50% of their HP."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}

}