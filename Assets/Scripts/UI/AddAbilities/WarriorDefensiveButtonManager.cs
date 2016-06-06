using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WarriorDefensiveButtonManager : MonoBehaviour {

	// Use this for initialization
	private SceneNavigator sceneNavigator;

	public List<Button> buttons = new List<Button>();
	private WarriorPlayer wp;

	void Start () {

		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		wp = (WarriorPlayer)FindObjectOfType<WarriorPlayer> ();
		SetUpButtons ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void AddTauntS()
	{
		wp.AddDefensiveAbility (new TauntS ());
		Advance ();
	}

	public void AddTauntM()
	{
		wp.RemoveDefensiveAbility (new TauntS());
		wp.AddDefensiveAbility (new TauntM());
		Advance ();
	}

	public void AddTauntL()
	{
		wp.RemoveDefensiveAbility (new TauntM());
		wp.AddDefensiveAbility (new TauntL());
		Advance ();
	}

	public void AddWeakRevive()
	{
		wp.AddDefensiveAbility (new WeakRevive ());
		Advance ();
	}

	public void AddWeakHeal()
	{
		wp.AddDefensiveAbility (new WeakHeal ());
		Advance ();
	}
		
	public void AddWithstand()
	{
		wp.AddDefensiveAbility (new Withstand());
		Advance ();
	}

	public void SetUpButtons()
	{
		foreach (Button b in buttons)
			b.interactable = false;

		buttons [0].interactable = true;
		buttons [3].interactable = true;
		buttons [4].interactable = true;
		buttons [5].interactable = true;

		foreach (DefensiveAbility da in wp.GetDefensiveAbilities()) {
			switch (da.GetAbilityTag ()) {
			case "Taunt S":
				buttons [0].interactable = false;
				buttons [1].interactable = true;
				break;

			case "Taunt M":
				buttons [0].interactable = false;
				buttons [2].interactable = true;
				break;

			case "Taunt L":
				buttons [0].interactable = false;
				break;

			case "Weak Revive":
				buttons [3].interactable = false;
				break;

			case "Weak Heal":
				buttons [4].interactable = false;
				break;

			case "Withstand":
				buttons [5].interactable = false;
				break;
			}
		}

	}

	public void Advance()
	{
		sceneNavigator.GoToPreScreen ();
	}

}