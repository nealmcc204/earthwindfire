using UnityEngine;
using System.Collections;

public abstract class BasePhysical : OffensiveAbility {

	public override ElementType AttackElement()
	{
		return ElementType.NONE;
	}
}

