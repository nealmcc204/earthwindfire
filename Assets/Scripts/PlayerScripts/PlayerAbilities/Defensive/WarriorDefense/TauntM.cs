using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TauntM : DefensiveAbility {

	public override bool Execute(List<Player> targets)
	{
		targets[0].SetTaunt (true);
		targets[0].SetDamageReduction (0.6f);
		return true;
	}

	public override string GetAbilityTag()
	{
		return "Taunt M";
	}

	public override string GetAbilityDescription()
	{
		string ad = "Forces Enemies to Target this unit until its next turn. Reduces incoming damage by 40%"; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}
}