using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatMediator : MonoBehaviour {

	// Use this for initialization
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
	private SceneNavigator sceneNavigator;
	private List<Unit> units;
	public GameObject buttonPrefab;
	private GameObject startButton;
	public GameObject scrollWindowPrefab;
	private GameObject scrollWindow;

	void Awake() {
		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		scrollWindow = (GameObject)Instantiate (scrollWindowPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
	}

	void Start () {
		startButton = (GameObject)Instantiate (buttonPrefab,gameObject.transform.position, Quaternion.identity);
		startButton.GetComponentInChildren<Text> ().text = "Start Fight.";
		startButton.GetComponentInChildren<Button> ().onClick.AddListener (() => StartGame ());
		startButton.transform.SetParent (gameObject.GetComponentInParent<Canvas> ().transform);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

	private void SortUnitsBySpeed(List<Unit> u)
	{
		for (int i = 0; i < u.Count - 1; i++) {
			for (int j = i + 1; j < u.Count; j++) {
				if (u [i].GetSpeed () < u [j].GetSpeed ()) {
					Unit temp = u [i];
					u [i] = u [j];
					u [j] = temp;
				}
			}
		}
		foreach (Unit un in u) {
			if (un.GetStatus() == Status.FROZEN) {//only frozen for one turn, once speed is calculated for this turn, unfrozen.
				un.SetStatus (Status.NONE);
			}
		}
	}

	public void TestFight()
	{
		foreach (Enemy e in enemyManager.Enemies) {
			e.DoMove (playerManager.Players, enemyManager.Enemies);
		}
		Debug.Log ("Execution Complete.");
		Debug.Log(String.Format("Warrior Player health {0} ", playerManager.Players[0].GetCurrentHealth()));
	}

	public void StartGame()
	{
		startButton.GetComponentInChildren<Button> ().interactable = false;
		units = new List<Unit> ();
		foreach (Player p in playerManager.Players) {
			units.Add (p);
		}
		foreach (Enemy e in enemyManager.Enemies) {
			units.Add (e);
		}

		StartCoroutine(CombatPhase ());
	}

	IEnumerator CombatPhase()
	{
		string moveData = "";
		string output = SceneManager.GetActiveScene ().name + "\n";
		while (!CombatComplete ()) {
			SortUnitsBySpeed (units);
			foreach (Unit u in units) {
				u.SetTurnComplete (false);
				if (u.GetTaunting ()) {
					u.SetTaunt (false);
				}
				if (!u.GetDead () && u.GetStatus() != Status.STUNNED && !CombatComplete()) {
					output += "\n" + u.gameObject.name + "\'s Turn. \n";
					moveData = u.DoMove (playerManager.Players, enemyManager.Enemies);				
					while (!u.GetTurnComplete ()) {
						yield return new WaitForSeconds(0.05f);
					}
					if (moveData == "")
						moveData = u.GetOutputLog ();

					output += moveData;
					scrollWindow.GetComponentInChildren<Text> ().text = output.Replace ("\n", Environment.NewLine);
				} else {
					u.SetStatus (Status.NONE);
				}
				yield return new WaitForSeconds (1.0f);
			}
		}
		foreach (Unit u in units) {
			u.GetComponentInChildren<Canvas> ().sortingOrder = 0;
		}
		WriteToOutputFile (output);

		if (Victory ())
			sceneNavigator.GoToVictoryScreen ();
		else
			sceneNavigator.GoToDefeatScreen ();
		//if victory go to victory / level up screen
		//if defeat try again
	}

	private bool Defeat()
	{
		foreach (Player p in playerManager.Players) {
			if (!p.GetDead ()) {
				return false;
			}
		}
		Debug.Log ("Defeat");
		return true;
	}

	private bool Victory()
	{
		foreach (Enemy e in enemyManager.Enemies) {
			if (!e.GetDead ()) {
				return false;
			}
		}
		Debug.Log ("Victory");
		return true;
	}

	private bool CombatComplete()
	{
		if (Victory () || Defeat ()) {
			return true;
		}
		return false;
	}

	private void WriteToOutputFile(string o)
	{
		string filename = "Results.txt";
		if (!System.IO.File.Exists(filename)) {
			System.IO.File.WriteAllText (filename, o);
		} else {
			System.IO.File.AppendAllText (filename, o);
		}
	}
}
