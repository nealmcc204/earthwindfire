using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireButtonManager : MonoBehaviour {

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

	public void AddSingleFireS()
	{
		mp.AddOffensiveAbility (new SingleFireS ());
		Advance ();
	}

	public void AddSingleFireM()
	{
		mp.RemoveOffensiveAbility (new SingleFireS());
		mp.AddOffensiveAbility (new SingleFireM ());
		Advance ();
	}

	public void AddSingleFireL()
	{
		mp.RemoveOffensiveAbility (new SingleFireM ());
		mp.AddOffensiveAbility (new SingleFireL ());
		Advance ();
	}

	public void AddSingleFireH()
	{
		mp.RemoveOffensiveAbility (new SingleFireL());
		mp.AddOffensiveAbility (new SingleFireH ());
		Advance ();
	}

	public void AddDoubleFireS()
	{
		mp.RemoveOffensiveAbility (new SingleFireS ());
		mp.AddOffensiveAbility (new DoubleFireS ());
		Advance ();
	}

	public void AddDoubleFireM()
	{
		mp.RemoveOffensiveAbility (new DoubleFireS ());
		mp.RemoveOffensiveAbility (new SingleFireM ());
		mp.AddOffensiveAbility (new DoubleFireM ());
		Advance ();
	}

	public void AddDoubleFireL()
	{
		mp.RemoveOffensiveAbility (new DoubleFireM ());
		mp.RemoveOffensiveAbility (new SingleFireL ());
		mp.AddOffensiveAbility (new DoubleFireL ());
		Advance ();
	}

	public void AddTripleFireS()
	{
		mp.RemoveOffensiveAbility (new DoubleFireS ());
		mp.AddOffensiveAbility (new TripleFireS ());
		buttons [0].interactable = false;
		buttons [3].interactable = false;
		Advance ();
	}

	public void AddTripleFireM()
	{
		mp.RemoveOffensiveAbility (new TripleFireS ());
		mp.RemoveOffensiveAbility (new DoubleFireM ());
		mp.AddOffensiveAbility (new TripleFireM ());
		foreach (Button b in buttons)
			b.interactable = false;

		Advance ();
	}

	public void AddAllFireS()
	{
		mp.RemoveOffensiveAbility (new TripleFireS ());
		mp.AddOffensiveAbility (new AllFireS ());
		foreach (Button b in buttons)
			b.interactable = false;

		Advance ();
	}

	public void SetUpButtons()
	{
		foreach (Button b in buttons)
			b.interactable = false;

		foreach (OffensiveAbility oa in mp.GetOffensiveAbilities()) {
			switch (oa.GetAbilityTag ()) {
			case "Single Fire S": 
				buttons [0].interactable = true;
				buttons [1].interactable = true;
				break;
			
			case "Single Fire M":
				buttons [3].interactable = true;
				buttons [4].interactable = true;
				break;

			case "Single Fire L":
				buttons [7].interactable = true;
				buttons [8].interactable = true;
				break;

			case "Single Fire H":
				break;

			case "Double Fire S":
				buttons [2].interactable = true;
				buttons [3].interactable = true;
				break;

			case "Double Fire M":
				buttons [6].interactable = true;
				buttons [7].interactable = true;
				break;

			case "Double Fire L":
				break;

			case "Triple Fire S":
				buttons [5].interactable = true;
				buttons [6].interactable = true;
				break;

			case "Triple Fire M":
				break;

			case "All Fire S":
				break;
			}
		}
	}

	public void Advance()
	{
		//SceneManager.LoadScene ("Level2");
		sceneNavigator.GoToMageWaterAbilities();
	}
}
