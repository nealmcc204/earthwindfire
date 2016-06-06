using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


public class MagePlayer : Player 
{
	public static MagePlayer mp;

	/*public static MagePlayer Instance {
		get {
			if (mp == null) {
				mp = FindObjectOfType<MagePlayer> ();
				if (mp == null) {
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					mp = obj.AddComponent<MagePlayer> ();
				}
			}
			return mp;
		}
	}*/	

	void Awake(){
		//DontDestroyOnLoad (this.gameObject);
		if (mp == null) {
			mp = this;
			SetMaxHealth(75);
			SetHealth(GetMaxHealth());
			SetSpeed(100);
			AddOffensiveAbility(new SingleFireS());
			AddOffensiveAbility (new SingleEarthS());
			AddOffensiveAbility (new SingleWaterS());
			AddDefensiveAbility (new SingleHealS());
			SetShield (ElementType.NONE);
		} else if (mp != this)  {
			Destroy (gameObject);
		}
			
	}

	/*void Awake() {
		if (!mp) {
			mp = this;
			DontDestroyOnLoad (gameObject);
			SetMaxHealth(75);
			SetHealth(GetMaxHealth());
			SetSpeed(100);
			AddOffensiveAbility(new SingleFireS());
			AddOffensiveAbility (new SingleEarthS());
			AddOffensiveAbility (new SingleWaterS());
			AddDefensiveAbility (new SingleHealS());
			SetShield (ElementType.NONE);
		} else {
			Destroy (gameObject);
		}
	}*/
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*public void AbilitySelectClicked()
	{
		string abilityName = gameObject.GetComponentInChildren<Text> ().text;
		ChooseSelectedAbility (abilityName);
	}*/
				
}
