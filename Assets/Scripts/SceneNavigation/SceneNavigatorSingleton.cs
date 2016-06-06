using UnityEngine;
using System.Collections;

public class SceneNavigatorSingleton : MonoBehaviour {

	// Use this for initialization
	public GameObject sceneNavigatorPrefab;
	public static GameObject sceneNavigator;

	void Awake() {
		sceneNavigator = (GameObject)Instantiate (sceneNavigatorPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		sceneNavigator.name = "Scene Navigator";
		DontDestroyOnLoad (sceneNavigator);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
