using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GreaterRevive : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		if (targets[0].GetDead()) {
			bool success = false;
			targets[0].Revive ();
			int heal = (int)(targets[0].GetMaxHealth () * 0.35);
			success = targets[0].RestoreHealth (heal);
			return success;
		} else {
			return false;
		}
	}

	public override string GetAbilityTag()
	{
		return "Greater Revive";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Revives a single target with 35% of their HP."; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}
}