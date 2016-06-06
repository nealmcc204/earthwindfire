using UnityEngine;
using System.Collections;

public class EffectsManager : MonoBehaviour {

	// Use this for initialization
	public GameObject fireball;
	public GameObject waterball;
	public GameObject earthball;
	public GameObject standardAttack;
	public GameObject healing;
	public GameObject revive;
	private GameObject obj;
	private bool finishedAnimating;
	float step;
	Vector3 endPos;

	// Update is called once per frame
	void Awake()
	{
		finishedAnimating = true;
		LoadImages ();
		step = (float)5* Time.deltaTime;

	}

	void Update () {
	
		if (obj != null) {
			finishedAnimating = false;
			obj.transform.position= Vector3.MoveTowards (obj.transform.position, endPos, step);
			if (obj.transform.position.x > 4.8)
				finishedAnimating = true;
				Destroy (obj);
		}

	}

	public void PlayEffects(OffensiveAbility oa)
	{
		if (obj != null)
			Destroy (obj);
		endPos = new Vector3 (5, 0, 0);
		
		switch (oa.AttackElement ()) {

		case ElementType.FIRE:
			
			obj = (GameObject)Instantiate (fireball, new Vector3 (-3, 0, 0), Quaternion.identity);
			break;

		case ElementType.EARTH:
			obj = (GameObject)Instantiate (earthball, new Vector3 (-3, 0, 0), Quaternion.identity);
			break;

		case ElementType.WATER:
			obj = (GameObject)Instantiate (waterball, new Vector3 (-3, 0, 0), Quaternion.identity);
			break;

		case ElementType.NONE:
			obj = (GameObject)Instantiate (standardAttack, new Vector3 (-3, 0, 0), Quaternion.identity);
			break;

		default:
			obj = null;
			break;
		}

	}

	public void PlayEffects(ElementType ele)
	{
		if (obj != null)
			Destroy (obj);
		endPos = new Vector3 (-3, 0, 0);

		switch (ele) {

		case ElementType.FIRE:

			obj = (GameObject)Instantiate (fireball, new Vector3 (5, 0, 0), Quaternion.identity);
			break;

		case ElementType.EARTH:
			obj = (GameObject)Instantiate (earthball, new Vector3 (5, 0, 0), Quaternion.identity);
			break;

		case ElementType.WATER:
			obj = (GameObject)Instantiate (waterball, new Vector3 (5, 0, 0), Quaternion.identity);
			break;

		case ElementType.NONE:
			obj = (GameObject)Instantiate (standardAttack, new Vector3 (5, 0, 0), Quaternion.identity);
			break;

		default:
			obj = null;
			break;
		}

	}

	public bool FinishedAnimating()
	{
		return finishedAnimating;
	}

	private void LoadImages()
	{
		standardAttack = (GameObject)Resources.Load ("Normal");
		fireball = (GameObject)Resources.Load ("Fireball");
		waterball = (GameObject)Resources.Load ("Water");
		earthball = (GameObject)Resources.Load ("Earth");
	}
		

	public void PlayEffects(DefensiveAbility da)
	{

	}
}
