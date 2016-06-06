﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	private SceneNavigator sceneNavigator;

	void Start () {
		sceneNavigator = (SceneNavigator)FindObjectOfType<SceneNavigator> ();
		Button b = GetComponentInParent<Button> ();
		b.GetComponentInChildren<Button> ().onClick.AddListener(() => Application.Quit());
	}

	// Update is called once per frame
	void Update () {

	}
}