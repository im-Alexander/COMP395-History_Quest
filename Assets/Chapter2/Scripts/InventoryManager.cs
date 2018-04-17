using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	public List<InventoryItem> inventoryItems = new List<InventoryItem> ();

	public int numCells;
	public float height, width;
	public float yPosition; //start if inventory display
	//MissionMgr
	private MissionMgr missionMgr;
	public void Add(InteractiveObj iObj){
		ObjectInteraction oi = iObj.OnCloseEnough;
		switch (oi.interactionType) {
		case ObjectInteraction.InteractionType.Unique:
			Insert (iObj);
			break;
		case ObjectInteraction.InteractionType.Accumulate:
			{
				bool inserted = false;
				CustomGameObj cgo = iObj.gameObject.GetComponent<CustomGameObj> ();
				CustomGameObj.CustomObjectType cot = CustomGameObj.CustomObjectType.Invalid;
				if (cgo != null) {
					cot = cgo.objectType; // type
				}
				for (int i = 0; i < inventoryItems.Count; i++) {
					CustomGameObj cgoi = inventoryItems[i].item.GetComponent<CustomGameObj> ();
					CustomGameObj.CustomObjectType coti = CustomGameObj.CustomObjectType.Invalid;
					if (cgoi != null) {
						coti = cgoi.objectType; // type
					}
					if (cot == coti) {//accumulate
						inventoryItems [i].quantity++;
						//deal with mission token
						MissionToken mt = iObj.gameObject.GetComponent<MissionToken> ();
						if (mt != null) {
							missionMgr.Add (mt);
							iObj.gameObject.SetActive (false);
							inserted = true;
							break;
						}
					} //if(cot == coti)
				}//for (

				if (!inserted) {
					Insert (iObj);
				}
			}//accumulate
			break;
		}//switch
	}

	public void Insert(InteractiveObj iObj){
		InventoryItem ii = new InventoryItem ();
		ii.item = iObj.gameObject;
		ii.quantity = 1;
		ii.item.SetActive (false);
		inventoryItems.Add (ii);
		//TODO: MissionMgr

		MissionToken mt=ii.item.GetComponent<MissionToken>();
		if (mt != null) {
			Debug.Log ("In InventoryMgr.Insert: mt=");
			Debug.Log (mt);
			missionMgr.Add (mt);
		}
	}

	void DisplayInventory(){
		float sw = Screen.width;
		float sh = Screen.height;
		Texture buttonTexture;
		Texture t;
		int totalCellsToDisplay = inventoryItems.Count;

		for (int i = 0; i < totalCellsToDisplay; i++) {
			InventoryItem ii = inventoryItems [i];
			int quantity = ii.quantity;
			float totalCellLength = sw - (numCells * width);
			float xcoord = totalCellLength - .5f * totalCellLength + width * i;
			GameObject go = ii.item;
		
			CustomGameObj cgoi = go.GetComponent<CustomGameObj> ();
			ObjectInteraction oi = go.GetComponent<ObjectInteraction> ();
			buttonTexture=oi.texture;

			Rect r = new Rect (xcoord, yPosition * sh, width, height);
			if (GUI.Button (r, buttonTexture)) {
				Debug.Log ("in GUI.Button.xcoord: " + xcoord);
			}
			string s = quantity.ToString ();
			Rect r2 = new Rect (xcoord, yPosition * sh, width/2, height/2);
			GUIStyle style = new GUIStyle ();

			GUI.Label (r2, s, "<font bgcolor=yellow color=red></font>");
		}

	}

	void OnGUI(){
		DisplayInventory();
	}
	// Use this for initialization
	void Start () 
	{
		GameObject goMM;
		goMM = GameObject.Find ("MissionManager");
		if (goMM) {
			missionMgr = goMM.GetComponent<MissionMgr> ();
			Debug.Log (missionMgr);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
