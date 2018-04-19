using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactDisplayManager : MonoBehaviour {
	public float targetTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetTime > 0.0f) {
			targetTime -= Time.deltaTime;
			Debug.Log (targetTime);
		} else {
			hideFactImage ();
		}
	}

	public void displayFactImage(Material historyFact){
		targetTime = 5.0f;
		Image image = GameObject.FindGameObjectWithTag ("HistoryFactUI").GetComponent ("Image") as Image;
		image.enabled = true;
		image.material = historyFact;
	}

	void hideFactImage(){
		Image image = GameObject.FindGameObjectWithTag ("HistoryFactUI").GetComponent ("Image") as Image;
		image.enabled = false;
		//image.material = null;
	}
}
