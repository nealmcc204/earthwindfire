using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {

	// Use this for initialization
	private SceneNavigator sceneNavigator;

	void Start () {
		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		Button b = GetComponentInParent<Button> ();
		b.GetComponentInChildren<Button> ().onClick.AddListener(() => sceneNavigator.GoToLevelUp());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
