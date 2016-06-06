using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EarthButtonManager : MonoBehaviour {

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

	public void AddSingleEarthS()
	{
		mp.AddOffensiveAbility (new SingleEarthS ());
		Advance ();
	}

	public void AddSingleEarthM()
	{
		mp.RemoveOffensiveAbility (new SingleEarthS());
		mp.AddOffensiveAbility (new SingleEarthM ());
		Advance ();
	}

	public void AddSingleEarthL()
	{
		mp.RemoveOffensiveAbility (new SingleEarthM ());
		mp.AddOffensiveAbility (new SingleEarthL ());
		Advance ();
	}

	public void AddSingleEarthH()
	{
		mp.RemoveOffensiveAbility (new SingleEarthL());
		mp.AddOffensiveAbility (new SingleEarthH ());
		foreach (Button b in buttons)
			b.interactable = false;

		Advance ();
	}

	public void AddDoubleEarthS()
	{
		mp.RemoveOffensiveAbility (new SingleEarthS ());
		mp.AddOffensiveAbility (new DoubleEarthS ());
		Advance ();
	}

	public void AddDoubleEarthM()
	{
		mp.RemoveOffensiveAbility (new DoubleEarthS ());
		mp.RemoveOffensiveAbility (new SingleEarthM ());
		mp.AddOffensiveAbility (new DoubleEarthM ());
		Advance ();
	}

	public void AddDoubleEarthL()
	{
		mp.RemoveOffensiveAbility (new DoubleEarthM ());
		mp.RemoveOffensiveAbility (new SingleEarthL ());
		mp.AddOffensiveAbility (new DoubleEarthL ());
		Advance ();
	}

	public void AddTripleEarthS()
	{
		mp.RemoveOffensiveAbility (new DoubleEarthS ());
		mp.AddOffensiveAbility (new TripleEarthS ());
		Advance ();
	}

	public void AddTripleEarthM()
	{
		mp.RemoveOffensiveAbility (new TripleEarthS ());
		mp.RemoveOffensiveAbility (new DoubleEarthM ());
		mp.AddOffensiveAbility (new TripleEarthM ());
		Advance ();
	}

	public void AddAllEarthS()
	{
		mp.RemoveOffensiveAbility (new TripleEarthS ());
		mp.AddOffensiveAbility (new AllEarthS ());
		Advance ();
	}

	public void SetUpButtons()
	{
		foreach (Button b in buttons)
			b.interactable = false;

		foreach (OffensiveAbility oa in mp.GetOffensiveAbilities()) {
			switch (oa.GetAbilityTag ()) {
			case "Single Earth S": 
				buttons [0].interactable = true;
				buttons [1].interactable = true;
				break;

			case "Single Earth M":
				buttons [3].interactable = true;
				buttons [4].interactable = true;
				break;

			case "Single Earth L":
				buttons [7].interactable = true;
				buttons [8].interactable = true;
				break;

			case "Single Earth H":
				break;

			case "Double Earth S":
				buttons [2].interactable = true;
				buttons [3].interactable = true;
				break;

			case "Double Earth M":
				buttons [6].interactable = true;
				buttons [7].interactable = true;
				break;

			case "Double Earth L":
				break;

			case "Triple Earth S":
				buttons [5].interactable = true;
				buttons [6].interactable = true;
				break;

			case "Triple Earth M":
				break;

			case "All Earth S":
				break;
			}
		}
	}

	public void Advance()
	{
		sceneNavigator.GoToMageHealingAbilities ();
	}
}
