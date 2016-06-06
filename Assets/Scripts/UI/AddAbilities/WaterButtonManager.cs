using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaterButtonManager : MonoBehaviour {

	// Use this for initialization
	private SceneNavigator sceneNavigator;

	public List<Button> buttons = new List<Button>();
	private MagePlayer mp;

	void Start () {
		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		mp = (MagePlayer)FindObjectOfType<MagePlayer> ();
		foreach (Button b in buttons)
			b.interactable = false;

		SetUpButtons ();
	}
	// Update is called once per frame
	void Update () {

	}

	public void AddSingleWaterS()
	{
		mp.AddOffensiveAbility (new SingleWaterS ());
		Advance ();
	}

	public void AddSingleWaterM()
	{
		mp.RemoveOffensiveAbility (new SingleWaterS());
		mp.AddOffensiveAbility (new SingleWaterM ());
		Advance ();
	}

	public void AddSingleWaterL()
	{
		mp.RemoveOffensiveAbility (new SingleWaterM ());
		mp.AddOffensiveAbility (new SingleWaterL ());
		Advance ();
	}

	public void AddSingleWaterH()
	{
		mp.RemoveOffensiveAbility (new SingleWaterL());
		mp.AddOffensiveAbility (new SingleWaterH ());
		foreach (Button b in buttons)
			b.interactable = false;
		Advance ();
	}

	public void AddDoubleWaterS()
	{
		mp.RemoveOffensiveAbility (new SingleWaterS ());
		mp.AddOffensiveAbility (new DoubleWaterS ());
		Advance ();
	}

	public void AddDoubleWaterM()
	{
		mp.RemoveOffensiveAbility (new DoubleWaterS ());
		mp.RemoveOffensiveAbility (new SingleWaterM ());
		mp.AddOffensiveAbility (new DoubleWaterM ());
		Advance ();
	}

	public void AddDoubleWaterL()
	{
		mp.RemoveOffensiveAbility (new DoubleWaterM ());
		mp.RemoveOffensiveAbility (new SingleWaterL ());
		mp.AddOffensiveAbility (new DoubleWaterL ());
		Advance ();
	}

	public void AddTripleWaterS()
	{
		mp.RemoveOffensiveAbility (new DoubleWaterS ());
		mp.AddOffensiveAbility (new TripleWaterS ());
		Advance ();
	}

	public void AddTripleWaterM()
	{
		mp.RemoveOffensiveAbility (new TripleWaterS ());
		mp.RemoveOffensiveAbility (new DoubleWaterM ());
		mp.AddOffensiveAbility (new TripleWaterM ());
		Advance ();
	}

	public void AddAllWaterS()
	{
		mp.RemoveOffensiveAbility (new TripleWaterS ());
		mp.AddOffensiveAbility (new AllWaterS ());
		Advance ();
	}

		public void SetUpButtons()
		{
			foreach (OffensiveAbility oa in mp.GetOffensiveAbilities()) {
				switch (oa.GetAbilityTag ()) {
				case "Single Water S": 
					buttons [0].interactable = true;
					buttons [1].interactable = true;
					break;

				case "Single Water M":
					buttons [3].interactable = true;
					buttons [4].interactable = true;
					break;

				case "Single Water L":
					buttons [7].interactable = true;
					buttons [8].interactable = true;
					break;

				case "Single Water H":
					break;

				case "Double Water S":
					buttons [2].interactable = true;
					buttons [3].interactable = true;
					break;

				case "Double Water M":
					buttons [6].interactable = true;
					buttons [7].interactable = true;
					break;

				case "Double Water L":
					break;

				case "Triple Water S":
					buttons [5].interactable = true;
					buttons [6].interactable = true;
					break;

				case "Triple Water M":
					break;

				case "All Water S":
					break;
				}
			}
		}

	public void Advance()
	{
		sceneNavigator.GoToMageEarthAbilities ();
	}
}
