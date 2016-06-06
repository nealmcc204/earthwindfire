using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealingButtonManager : MonoBehaviour {

	// Use this for initialization
	private SceneNavigator sceneNavigator;

	public List<Button> buttons = new List<Button>();
	private MagePlayer mp;

	void Start () {
		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		mp = (MagePlayer)FindObjectOfType<MagePlayer> ();
		SetUpButtons ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void AddSingleHealS()
	{
		mp.AddDefensiveAbility (new SingleHealS ());
		Advance ();
	}

	public void AddSingleHealM()
	{
		mp.RemoveDefensiveAbility (new SingleHealS());
		mp.AddDefensiveAbility (new SingleHealM ());
		buttons [0].interactable = false;
		buttons [1].interactable = false;

		buttons [2].interactable = true;
		buttons [3].interactable = true;
		Advance ();
	}

	public void AddSingleHealL()
	{
		mp.RemoveDefensiveAbility (new SingleHealM ());
		mp.AddDefensiveAbility (new SingleHealL ());
		buttons [0].interactable = false;
		buttons [1].interactable = false;
		buttons [2].interactable = false;
		buttons [3].interactable = false;
		Advance ();
	}

	public void AddDoubleHealS()
	{
		mp.RemoveDefensiveAbility (new SingleHealS ());
		mp.AddDefensiveAbility (new DoubleHealS ());
		buttons [0].interactable = false;
		buttons [1].interactable = false;

		buttons [2].interactable = true;
		buttons [3].interactable = true;
		Advance ();
	}

	public void AddDoubleHealM()
	{
		mp.RemoveDefensiveAbility (new DoubleHealS ());
		mp.RemoveDefensiveAbility (new SingleHealM ());
		mp.AddDefensiveAbility (new DoubleHealM ());
		Advance ();
	}

	public void AddDoubleHealL()
	{
		mp.RemoveDefensiveAbility (new DoubleHealM ());
		mp.RemoveDefensiveAbility (new SingleHealL ());
		mp.AddDefensiveAbility (new DoubleHealL ());
		Advance ();
	}

	public void AddLesserRevive()
	{
		mp.AddDefensiveAbility (new LesserRevive ());
		Advance ();
	}

	public void AddRevive()
	{
		mp.RemoveDefensiveAbility (new LesserRevive ());
		mp.AddDefensiveAbility (new Revive ());
		Advance ();
	}

	public void AddGreaterRevive()
	{
		mp.RemoveDefensiveAbility (new Revive ());
		mp.AddDefensiveAbility (new GreaterRevive ());
		Advance ();
	}

	public void AddSingleWaterShield()
	{
		mp.AddDefensiveAbility (new SingleWaterShield ());
		Advance ();
	}

	public void AddDoubleWaterShield()
	{
		mp.RemoveDefensiveAbility (new SingleWaterShield ());
		mp.AddDefensiveAbility (new DoubleWaterShield ());
		Advance ();
	}

	public void AddSingleFireShield()
	{
		mp.AddDefensiveAbility (new SingleFireShield ());
		Advance ();
	}

	public void AddDoubleFireShield()
	{
		mp.RemoveDefensiveAbility (new SingleFireShield ());
		mp.AddDefensiveAbility (new DoubleFireShield ());
		Advance ();
	}

	public void AddSingleEarthShield()
	{
		mp.AddDefensiveAbility (new SingleEarthShield ());
		Advance ();
	}

	public void AddDoubleEarthShield()
	{
		mp.RemoveDefensiveAbility (new SingleEarthShield ());
		mp.AddDefensiveAbility (new DoubleEarthShield ());
		Advance ();
	}

	public void SetUpButtons()
	{
		foreach (Button b in buttons)
			b.interactable = false;
		
		buttons [5].interactable = true;
		buttons [8].interactable = true;
		buttons [10].interactable = true;
		buttons [12].interactable = true;

		foreach (DefensiveAbility da in mp.GetDefensiveAbilities()) {
			switch (da.GetAbilityTag()) {
			case "Single Heal S":
				buttons [0].interactable = true;
				buttons [1].interactable = true;
				break;
			case "Double Heal S":
				buttons [2].interactable = true;
				buttons [3].interactable = true;
				break;

			case "Single Heal M":
				buttons [2].interactable = true;
				buttons [3].interactable = true;
				break;

			case "Double Heal M":
				break;

			case "Single Heal Full":
				break;

			case "Lesser Revive": 
				buttons [5].interactable = false;
				buttons [6].interactable = true;
				break;

			case "Revive": 
				buttons [5].interactable = false;
				buttons [7].interactable = true;
				break;

			case "Greater Revive":
				buttons [5].interactable = false;
				break;

			case "Single Water Shield":
				buttons [8].interactable = false;
				buttons [9].interactable = true;
				break;

			case "Double Water Shield":
				break;

			case "Single FireShield":
				buttons [10].interactable = false;
				buttons [11].interactable = true;
				break;

			case "Double Fire Shield":
				break;

			case "Single Earth Shield":
				buttons [12].interactable = false;
				buttons [13].interactable = true;
				break;

			case  "Double Earth Shield":
				break;
			}
		}
	}

	public void Advance()
	{
		sceneNavigator.GoToWarriorOffensiveAbilities ();
	}

}