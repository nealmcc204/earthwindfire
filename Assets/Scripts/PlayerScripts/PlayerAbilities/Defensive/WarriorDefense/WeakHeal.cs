using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeakHeal : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		bool success = false;
		int heal = (int)(targets[0].GetMaxHealth() / 8);
		success = targets[0].RestoreHealth (heal);
		return success;
	}

	public override string GetAbilityTag()
	{
		return "Weak Heal";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Heals a single friendly target for 10% of their HP."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}

}
