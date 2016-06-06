using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class OffensiveAbility : BaseAbility {

	public abstract bool Execute(List<Enemy> targets);
	public abstract ElementType AttackElement ();

	protected int SmallDamage()
	{
		return 25;
	}

	protected int MediumDamage()
	{
		return 40;
	}

	protected int LargeDamage()
	{
		return 55;
	}

	protected int HugeDamage()
	{
		return 75;
	}
}
