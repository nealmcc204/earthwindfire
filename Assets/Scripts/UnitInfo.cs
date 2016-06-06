using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitInfo : MonoBehaviour {

	int maxHealth;
	public GameObject healthImage;
	public GameObject shieldStatus;
	private Component namePlate;
	private Component healthBar;
	Component[] objects;
	Vector3 healthScale;
	string healthText;
	Unit self;

	// Use this for initialization
	void Awake () {
		self = gameObject.GetComponent<Unit> ();
		objects = GetComponentsInChildren<Component> ();
		foreach (Component obj in objects) {
			if (obj.name == "NamePlate")
				namePlate = obj;
			else if (obj.name == "HealthBar")
				healthBar = obj;
		}
	}
	
	// Update is called once per frame
	void Update () {
		maxHealth = self.GetMaxHealth ();
		healthScale = new Vector3 (1f, 1f, 1f);
		healthText = maxHealth + "/" + maxHealth;
		healthBar.GetComponentInChildren<Text> ().text = healthText;
		healthImage.transform.localScale = healthScale; 
		healthScale.x = GetPercentageHealth ();
		healthImage.transform.localScale = healthScale;
		UpdateHealthText ();
		healthBar.GetComponentInChildren<Text> ().text = healthText;
		UpdateHealthColour ();
		UpdateShieldColour ();
	}

	public float GetPercentageHealth()
	{
		float percent = ((float)gameObject.GetComponentInParent<Unit> ().GetCurrentHealth ()) / (float)maxHealth;
		return percent;
	}

	public void UpdateHealthText()
	{
		healthText = self.GetCurrentHealth () + "/" + maxHealth;
	}

	public void UpdateHealthColour()
	{
		switch (self.GetStatus ()) {

		case Status.BURNED:
			healthImage.GetComponent<Image> ().color = new Color (1f, 0.5f, 0f);
			break;

		case Status.FROZEN:
			healthImage.GetComponent<Image> ().color = Color.cyan;
			break;

		case Status.DAZED:
			healthImage.GetComponent<Image> ().color = Color.yellow;
			break;

		case Status.STUNNED:
			healthImage.GetComponent<Image> ().color = Color.grey;
			break;

		default:
			healthImage.GetComponent<Image> ().color = Color.green;
			break;
		}
	}

	public void UpdateShieldColour()
	{
		switch (self.GetShield ().GetShieldType ()) {
		case ElementType.FIRE:
			shieldStatus.GetComponent<Image> ().color = new Color (1f, 0.5f, 0f);
			break;

		case ElementType.WATER:
			shieldStatus.GetComponent<Image> ().color = Color.cyan;
			break;

		case ElementType.EARTH:
			shieldStatus.GetComponent<Image> ().color = Color.yellow;
			break;

		default:
			shieldStatus.GetComponent<Image> ().color = Color.white;
			break;
		
		}
	}
}
