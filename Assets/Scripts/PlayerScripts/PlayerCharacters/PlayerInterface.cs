using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public abstract class Player : Unit {

    public List<DefensiveAbility> defensiveAbilities = new List<DefensiveAbility>();
    public List<OffensiveAbility> offensiveAbilities = new List<OffensiveAbility>();
	public GameObject buttonPrefab;
	private List<Enemy> selectedEnemyTargets = new List<Enemy>();
	private List<Player> selectedFriendlyTargets = new List<Player> ();
	private OffensiveAbility selectedOffensiveAbility;
	private DefensiveAbility selectedDefensiveAbility;
	private BaseAbility selectedAbility;
	private Canvas canvas;
	private List<GameObject> buttons = new List<GameObject> ();
	private int numTargets;
	string fullLog;

	public override string DoMove(List<Player> players, List<Enemy> enemies)
	{
		fullLog = "";
		offensiveAbilities.TrimExcess ();
		defensiveAbilities.TrimExcess ();
		players.TrimExcess ();
		enemies.TrimExcess ();
		StartCoroutine(TakeTurn(players,enemies));
		return "";
	}

	IEnumerator TakeTurn(List<Player> players, List<Enemy> enemies)
	{
		//UseAbility (defensiveAbilities [0], players [0]);
		string log;
		canvas = GetComponentInChildren<Canvas>();
		CreateTurnAbilityButtons();
		while (GetSelectedOffensiveAbility () == null && GetSelectedDefensiveAbility() == null) {
			yield return null;
		}
		RemoveButtons ();
		if (GetSelectedAbility () is OffensiveAbility) {
			
			numTargets = GetSelectedOffensiveAbility ().GetNumTargets ();
			if (numTargets > GetNumLivingEnemies (enemies))
				numTargets = GetNumLivingEnemies (enemies);
			
			CreateEnemyTargetButtons (enemies);

			while (numTargets > selectedEnemyTargets.Count) {
				yield return null;
			}
			RemoveButtons ();
			UseAbility (GetSelectedOffensiveAbility (), selectedEnemyTargets);
			log = "Used " + GetSelectedOffensiveAbility ().GetAbilityTag () + " against ";
			foreach (Enemy e in selectedEnemyTargets) {
				log += e.gameObject.name + ", ";
			}
			log += "\n";
		} 

		else {
			string abilityTag = GetSelectedDefensiveAbility ().GetAbilityTag ();
			if (abilityTag.Contains ("Taunt") || abilityTag.Contains ("Withstand")) {
				List<Player> tempTarg = new List<Player> ();
				foreach (Player p in players) {
					if (p is WarriorPlayer) {
						tempTarg.Add (p);
						break;
					}
				}
				UseAbility (GetSelectedDefensiveAbility (), tempTarg);
				log = "Used" + abilityTag + "\n";

			} else {
				numTargets = GetSelectedDefensiveAbility ().GetNumTargets ();
				if (numTargets == 1) {
					CreatePlayerTargetButtons (players);

					while (numTargets > selectedFriendlyTargets.Count) {
						yield return null;
					}
					RemoveButtons ();
					UseAbility (GetSelectedDefensiveAbility (), selectedFriendlyTargets);
					log = "Used " + GetSelectedDefensiveAbility ().GetAbilityTag () + " on a";
					foreach (Player p in selectedFriendlyTargets) {
						log += p.gameObject.name + ", ";
					}
					log += "\n";
				} else {
					UseAbility (GetSelectedDefensiveAbility (), players);
					log = "Used " + GetSelectedDefensiveAbility ().GetAbilityTag () + " on ";
					foreach (Player p in players) {
						log += p.gameObject.name + ", ";
					}
					log += "\n";
				}
			}

		}
		ResetSelectedAbilities ();
		ResetSelectedTargets ();
		SetOutputLog (log);
		SetTurnComplete (true);
	}

	public void CreateTurnAbilityButtons()
	{
		int x = 100; int y = 50; int count = 0;
		foreach (OffensiveAbility oa in offensiveAbilities) {
			GameObject button = new GameObject ();
			OffensiveAbility captured = oa;
			buttons.Add (button);
			buttons[count] = (GameObject)Instantiate (buttonPrefab, new Vector3(x,50+ y*count,0), Quaternion.identity);
			buttons[count].GetComponentInChildren<Text> ().text = oa.GetAbilityTag ();
			buttons[count].GetComponentInChildren<Button> ().onClick.AddListener(() => SetSelectedOffensiveAbility (captured));
			buttons[count].transform.SetParent (canvas.transform);
			count++;

		}

		foreach (DefensiveAbility da in defensiveAbilities) {
			GameObject button = new GameObject ();
			DefensiveAbility captured = da;
			buttons.Add (button);
			buttons[count] = (GameObject)Instantiate (buttonPrefab, new Vector3(x,50+y*count,0), Quaternion.identity);
			buttons[count].GetComponentInChildren<Text> ().text = da.GetAbilityTag ();
			buttons[count].GetComponentInChildren<Button> ().onClick.AddListener(() => SetSelectedDefensiveAbility (captured));
			buttons[count].transform.SetParent (canvas.transform);
			count++;
		}
	}

	public void CreateEnemyTargetButtons(List<Enemy> targets)
	{
		int x = 100; int y = 50; int count = 0;
		List<Enemy> taunters = GetTauntingEnemies (targets);
		List<Enemy> temp = new List<Enemy> ();
		temp.AddRange(targets);

		if (taunters.Count > 0) {//replaces the targets with the taunting enemies
			targets.Clear ();
			targets.AddRange(taunters);
			numTargets = 1;
		}

		foreach (Enemy t in targets) {
			if (!t.GetDead()) {
			GameObject button = new GameObject ();
			Enemy captured = t;
			buttons.Add (button);
			buttons[count] = (GameObject)Instantiate (buttonPrefab, new Vector3 (x, 50+ y*count, 0), Quaternion.identity);
			buttons[count].GetComponentInChildren<Text> ().text = t.name;
			buttons[count].GetComponentInChildren<Button> ().onClick.AddListener (() => AddToSelectedEnemyTargets (captured));
			buttons[count].transform.SetParent (canvas.transform);
			count++;
			}
		}

		targets.Clear ();
		targets.AddRange(temp);
	}

	public void CreatePlayerTargetButtons(List<Player> targets)
	{
		int x = 100; int y = 50; int count = 0;

		foreach (Player t in targets) {
			GameObject button = new GameObject ();
			Player captured = t;
			buttons.Add (button);
			buttons[count] = (GameObject)Instantiate (buttonPrefab, new Vector3 (x,50 + y*count, 0), Quaternion.identity);
			buttons[count].GetComponentInChildren<Text> ().text = t.name;
			buttons[count].GetComponentInChildren<Button> ().onClick.AddListener (() => AddToSelectedFriendlyTargets (captured));
			buttons[count].transform.SetParent (canvas.transform);
			count++;
		}
	}

	public void AddToSelectedEnemyTargets(Enemy target)
	{
		foreach(Enemy e in selectedEnemyTargets)//dont add same target twice
		{
			if (e == target)
				return;
		}
		selectedEnemyTargets.Add (target);
	}

	public void AddToSelectedFriendlyTargets(Player target)
	{
		foreach(Player p in selectedFriendlyTargets)//dont add same target twice
		{
			if (p == target)
				return;
		}
		selectedFriendlyTargets.Add (target);
	}

	public int GetNumLivingEnemies(List<Enemy> enemies)
	{
		int count = 0;
		foreach (Enemy e in enemies) {
			if (!e.GetDead ())
				count++;
			}
		return count;
	}

	public void RemoveButtons()
	{
		foreach (GameObject g in buttons) {
			Destroy (g);
		}
	}

	public void AddOffensiveAbility(OffensiveAbility oa)
	{
		bool present = false;
		string log;
		foreach (OffensiveAbility i in offensiveAbilities)
		{
			if (i.GetAbilityTag() == oa.GetAbilityTag())
			{
				present = true;
			}
		}
		if (!present) {
			offensiveAbilities.Add (oa);
			log = ("\nAbility " + oa.GetAbilityTag () + " added.\n");
			Debug.Log (log);
			WriteToOutputFile (log);
		} else {
			Debug.Log ("Ability " + oa.GetAbilityTag () + " already present.");
		}
	}

	public void RemoveOffensiveAbility(OffensiveAbility oa)
	{
		foreach (OffensiveAbility i in offensiveAbilities) {
			if (i.GetAbilityTag() == oa.GetAbilityTag()) {
				offensiveAbilities.Remove (i);
				break;
			}
		}
	}

	public void AddDefensiveAbility(DefensiveAbility da)
	{
		bool present = false;
		string log;
		foreach (DefensiveAbility i in defensiveAbilities)
		{
			if (i.GetAbilityTag() == da.GetAbilityTag())
			{
				present = true;
			}
		}
		if (!present) {
			defensiveAbilities.Add (da);
			log = ("\nAbility " + da.GetAbilityTag () + " added.\n");
			Debug.Log (log);
			WriteToOutputFile (log);
		} else {
			Debug.Log ("Ability " + da.GetAbilityTag () + " already present.");
		}
	}

	public void RemoveDefensiveAbility(DefensiveAbility da)
	{
		foreach (DefensiveAbility i in defensiveAbilities) {
			if (i.GetAbilityTag() == da.GetAbilityTag()) {
				defensiveAbilities.Remove (i);
				break;
			}
		}
	}

	public bool UseAbility(DefensiveAbility ab, List<Player> targets)
	{
		bool result = false;
		//PlayEffects (ab);
		result = ab.Execute (targets);

		return result;
	}

	public bool UseAbility(OffensiveAbility ab, List<Enemy> targets)
	{
		bool result = false;
		result = ab.Execute (targets);
		return result;
	}

	public List<DefensiveAbility> GetDefensiveAbilities()
	{
		return defensiveAbilities;
	}

	public List<OffensiveAbility> GetOffensiveAbilities()
	{
		return offensiveAbilities;
	}

	public void SetSelectedOffensiveAbility(OffensiveAbility oa)
	{
		selectedOffensiveAbility = oa;
		selectedAbility = oa;
	}

	public OffensiveAbility GetSelectedOffensiveAbility()
	{
		return selectedOffensiveAbility;
	}

	public void SetSelectedDefensiveAbility(DefensiveAbility da)
	{
		selectedDefensiveAbility = da;
		selectedAbility = da;
	}

	public DefensiveAbility GetSelectedDefensiveAbility()
	{
		return selectedDefensiveAbility;
	}

	public BaseAbility GetSelectedAbility()
	{
		return selectedAbility;
	}

	public void ResetSelectedAbilities()
	{
		selectedOffensiveAbility = null;
		selectedDefensiveAbility = null;
		selectedAbility = null;
	}

	public void ResetSelectedTargets()
	{
		selectedEnemyTargets.Clear ();
		selectedFriendlyTargets.Clear ();
	}

	public List<Enemy> GetTauntingEnemies(List<Enemy> enemies)
	{
		List<Enemy> taunters = new List<Enemy> ();
		foreach (Enemy e in enemies) {
			if (e.GetTaunting ())
				taunters.Add (e);
		}
		return taunters;
	}

	private void WriteToOutputFile(string o)
	{
		//string path = @"C:\Users\Neal\Documents\devproject\";
		//string filename = path; 
		string filename = "Results.txt";
		if (!System.IO.File.Exists(filename)) {
			System.IO.File.WriteAllText (filename, o);
		} else {
			System.IO.File.AppendAllText (filename, o);
		}
	}
}
