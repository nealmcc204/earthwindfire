using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

 public abstract class Enemy : Unit {

	bool stunned;


	protected Player FindLowestPercentageHealth (List<Player> units)
	{
		if (units.Count == 0)
			return null;
		
		Player target = units[0];
			
		float targetPercentageHp = 2;
		foreach (Player u in units) {
			if (!u.GetDead ()) {
				float nextPercentageHp = (float)u.GetCurrentHealth () / (float)u.GetMaxHealth ();
				if (nextPercentageHp < targetPercentageHp) {
					target = u;
				}
				targetPercentageHp = (float)target.GetCurrentHealth () / (float)target.GetMaxHealth ();
			}
		}
		return target;
	}

	protected Enemy FindLowestPercentageHealth(List<Enemy> units)
	{
		if (units.Count == 0)
			return null;

		Enemy target = units[0];
			
		float targetPercentageHp = 2;
		foreach (Enemy u in units) {
			float nextPercentageHp = (float)u.GetCurrentHealth () / (float)u.GetMaxHealth ();
			if (nextPercentageHp < targetPercentageHp) {
				target = u;
			}
			targetPercentageHp = (float)target.GetCurrentHealth () / (float)target.GetMaxHealth ();
		}

		return target;
	}

	protected ElementType RandomElement()
	{
		Array enums = Enum.GetValues (typeof(ElementType));
		System.Random ran = new System.Random ();
		ElementType ranEle = (ElementType)enums.GetValue(ran.Next(enums.Length));
		return ranEle;
	}

	protected Player GetTaunter (List<Player> units)
	{
		foreach (Player p in units) {
			if (p.GetTaunting ()) {
				return p;
			}
		}
		return null;
	}

}
