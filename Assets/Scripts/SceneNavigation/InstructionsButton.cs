using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionsButton : MonoBehaviour {

	// Use this for initialization
	private SceneNavigator sceneNavigator;

	void Start () {
		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		Button b = GetComponentInParent<Button> ();
		b.GetComponentInChildren<Button> ().onClick.AddListener(() => sceneNavigator.GoToInstructions());
	}

	// Update is called once per frame
	void Update () {

	}
}