using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WarriorPlayer : Player
{
	public static WarriorPlayer wp;

	/*(public static WarriorPlayer Instance {//this and awake make warrior a singleton
		get {
			if (wp == null) {
				wp = FindObjectOfType<WarriorPlayer> ();
				if (wp == null) {
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					wp = obj.AddComponent<WarriorPlayer> ();
				}
			}
			return wp;
		}
	}*/

	void Awake(){

		//DontDestroyOnLoad (this.gameObject);
		if (wp == null) {
			wp = this;
			SetMaxHealth(100);
			SetHealth(GetMaxHealth());
			SetSpeed(75);
			AddOffensiveAbility (new StunSmashS());
			AddOffensiveAbility (new DoubleStrikeS ());
			SetShield (ElementType.NONE);
			SetShield (ElementType.NONE);
		} else {
			Destroy (gameObject);
		}

	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public override bool ReduceHealth(int damage, Shield s, ElementType ae)
	{
		if (GetTaunting ()) {
			damage = (int)(damage * GetDamageReduction ());
			Debug.Log ("Warrior took reduced damage.");
		}

		if (s.GetShieldType() == ElementType.NONE || s.GetShieldType() != ae) {
			SetStatus(CalculateStatus (ae));
			SetHealth(GetCurrentHealth() - damage);
			if (GetCurrentHealth () <= 0) {
				if (GetWithstanding ()) {
					SetHealth (1);
					SetWithstanding (false);
				}
				else {
					SetHealth (0);
					SetDead (true);
				}
			}
			return true;
		} 
		else {
			this.SetShield (ElementType.NONE);
			return false;
		}
	}
}
