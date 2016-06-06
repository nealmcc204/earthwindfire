using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    // Use this for initialization
	public GameObject magePrefab;
	public GameObject warriorPrefab;
	public static GameObject magePlayer;
	public static GameObject warriorPlayer;

	public List<Player> Players = new List<Player>();
    
    
    void Awake () {
		warriorPlayer = GameObject.Find ("Warrior Player");
		if (warriorPlayer == null) {
			warriorPlayer = (GameObject)Instantiate (warriorPrefab, new Vector3 (50, -100, 0), Quaternion.identity);
			warriorPlayer.name = "Warrior Player";
		}
		warriorPlayer.GetComponentInChildren<Canvas> ().sortingOrder = 1;
		DontDestroyOnLoad (warriorPlayer);
		Players [0] = warriorPlayer.GetComponentInChildren<WarriorPlayer> ();

		magePlayer = GameObject.Find ("Mage Player");
		if (magePlayer == null) {
			magePlayer = (GameObject)Instantiate (magePrefab, new Vector3 (50, 0, 0), Quaternion.identity);
			magePlayer.name = "Mage Player";
		}
		magePlayer.GetComponentInChildren<Canvas> ().sortingOrder = 1;
		DontDestroyOnLoad (magePlayer);
		Players [1] = magePlayer.GetComponentInChildren<MagePlayer> ();

		foreach (Player p in Players) {
			p.SetMaxHealth((int)(p.GetMaxHealth() + 10));
			p.Revive ();
			p.SetHealth (p.GetMaxHealth());
		}
		//magePlayer.transform.SetParent (canvas.transform, true);
		//GameObject character;
		//character = (GameObject)Instantiate (magePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		//Players [0] =(MagePlayer)FindObjectOfType<MagePlayer> ();
		//character = (GameObject)Instantiate (warriorPrefab, new Vector3 (50, 0, 0), Quaternion.identity);
		//Players [1] = character.GetComponentInChildren<WarriorPlayer> ();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
;