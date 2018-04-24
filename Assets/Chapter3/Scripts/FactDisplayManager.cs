using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactDisplayManager : MonoBehaviour {
	public float targetTime = 0f;
	public bool buttonEnabled;
	public GameObject hideButton;

	private float saveTime;
	private Image hideButtonImage;

	// Use this for initialization
	void Start () {
		saveTime = targetTime;
		targetTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (buttonEnabled == false) {
			if (targetTime > 0.0f) {
				targetTime -= Time.deltaTime;
			} else {
				hideFactImage ();
			}
		}
	}

	public void displayFactImage(Material historyFact){
		if (buttonEnabled == false) {
			targetTime = saveTime;
		} else {
			hideButtonImage = hideButton.GetComponent("Image") as Image;
			hideButtonImage.enabled = true;
			Debug.Log ("Test");
		}
		Image image = GameObject.FindGameObjectWithTag ("HistoryFactUI").GetComponent ("Image") as Image;
		image.enabled = true;
		image.material = historyFact;
	}

	public void hideFactImage(){
		Image image = GameObject.FindGameObjectWithTag ("HistoryFactUI").GetComponent ("Image") as Image;
		image.enabled = false;
		hideButtonImage = hideButton.GetComponent("Image") as Image;
		hideButtonImage.enabled = false;
	}
}
