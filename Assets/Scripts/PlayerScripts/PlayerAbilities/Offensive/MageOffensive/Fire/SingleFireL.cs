﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleFireL : BaseFire {

	public override bool Execute(List<Enemy> targets)
	{
		bool success = false;
		success = targets[0].ReduceHealth (LargeDamage(), targets[0].GetShield(), AttackElement() );
		if (success) {
			targets[0].SetStatus (Status.BURNED);
		}
		return success;
	}


	public override string GetAbilityTag()
	{
		string at = "Single Fire L";
		return at;
	}

	public override string GetAbilityDescription()
	{
		string ad = "Deals" + LargeDamage() + "of fire damage to a single enemy, and burns them. "; 
		return ad;
	}
		
	public override int GetNumTargets()
	{
		return 1;
	}
}