using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomGameObj : MonoBehaviour {
	public enum CustomObjectType
	{
		Invalid=-1,
		Unique=0,
		Coin=1,
		Ruby=2,
		Emerald=3,
		Diamond=4
	}

	public CustomObjectType objectType;

	public string displayName;

	public void validate(){
		if (displayName == "")
			displayName = "unnamed_object";	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
