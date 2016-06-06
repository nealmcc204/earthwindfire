using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkipLevel : MonoBehaviour {

	// Use this for initialization
	private EnemyManager enemyManager;

	void Start () {
		enemyManager = (EnemyManager)FindObjectOfType<EnemyManager> ();
		Button b = GetComponentInParent<Button> ();
		b.GetComponentInChildren<Button> ().onClick.AddListener(() => KillAllEnemies());
	}

	// Update is called once per frame
	void Update () {

	}

	private void KillAllEnemies()
	{
		foreach (Enemy e in enemyManager.Enemies) {
			e.SetHealth (0);
			e.SetDead (true);
		}
	}
}
