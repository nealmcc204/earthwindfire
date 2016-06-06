using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    // Use this for initialization
	public List<Enemy> Enemies = new List<Enemy>();

    void Awake () {
        int health =  Enemies[0].GetCurrentHealth();
        health = Enemies[1].GetCurrentHealth();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}