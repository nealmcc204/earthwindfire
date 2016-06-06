using UnityEngine;
using System.Collections;

public abstract class BaseEarth : OffensiveAbility {

	public override ElementType AttackElement()
	{
		return ElementType.EARTH;
	}
}

