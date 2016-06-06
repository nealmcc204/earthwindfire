using UnityEngine;
using System.Collections;

public class Shield {

	// Use this for initialization
	ElementType element;

	public Shield()
	{
		element = ElementType.NONE;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetShieldType(ElementType e)
	{
		element = e;
	}

	public ElementType GetShieldType()
	{
		return element;
	}
}
