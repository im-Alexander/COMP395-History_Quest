using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractiveObj : MonoBehaviour {
	public Vector3 rotAxis;
	public float rotSpeed;
	public Material historyFact;
	public ObjectInteraction OnCloseEnough;
	public FactDisplayManager factDisplayer;

	private CustomGameObj customGameObj;

	// Use this for initialization
	void Start () {
		customGameObj = this.GetComponent<CustomGameObj> ();
		if (customGameObj != null) {
			customGameObj.validate ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotAxis, rotSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if (OnCloseEnough != null) {
				factDisplayer.displayFactImage (historyFact);
				OnCloseEnough.HandleInteraction ();
			}
		}
	}
}
