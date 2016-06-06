using UnityEngine;
using System.Collections;

public abstract class BaseWater : OffensiveAbility {

	public override ElementType AttackElement()
	{
		return ElementType.WATER;
	}
}
