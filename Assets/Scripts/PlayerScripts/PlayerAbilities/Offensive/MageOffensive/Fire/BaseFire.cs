using UnityEngine;
using System.Collections;

public abstract class BaseFire : OffensiveAbility {

	public override ElementType AttackElement()
	{
		return ElementType.FIRE;
	}
}
