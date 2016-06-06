using UnityEngine;
using System.Collections;

public class EffectsManagerController : MonoBehaviour {

	// Use this for initialization
	public GameObject effectsManagerPrefab;
	public static GameObject effectsManager;

	void Awake() {
		effectsManager = (GameObject)Instantiate (effectsManagerPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		effectsManager.name = "Effects Manager";
		DontDestroyOnLoad (effectsManager);
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
