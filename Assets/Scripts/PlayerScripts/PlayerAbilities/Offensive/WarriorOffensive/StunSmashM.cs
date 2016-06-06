using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StunSmashM : BasePhysical {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		success = targets[0].ReduceHealth (MediumDamage(), targets[0].GetShield(), AttackElement() );
		if (success) {
			targets[0].SetStatus (Status.STUNNED);
		}
		return success;
	}


	public override string GetAbilityTag()
	{
		string at = "Stun Smash M";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + MediumDamage() + "of physical damage to a single enemy, and stuns them. "; 
		return ad;
	}

	public override int GetNumTargets()
	{
		return 1;
	}
}