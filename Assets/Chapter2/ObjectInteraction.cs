using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {
	public enum InteractionType
	{
		Invalid=-1,
		Unique=0,
		Accumulate=1
	}

	public enum InteractionAction
	{
		Invalid=-1,
		PutInInventory=0,
		Use=1,
		Drop=2
	}

	public InteractionType interactionType;
	public InteractionAction interactionAction;
	public Texture texture;
	private GameObject player;
	private InventoryManager inventoryManager;
	public void HandleInteraction(){
		if (interactionAction == InteractionAction.PutInInventory) {
			if (inventoryManager) {
				//TODO: inventoryManager.Add(this.gameObject.GetComponent<InteractiveObj>());
				GameObject go=this.gameObject;
				InteractiveObj iObj = go.GetComponent<InteractiveObj> ();
				Debug.Log ("In ObjectInteraction.HandleInteraction:");
				Debug.Log (iObj);
				//inventoryManager.Add(this.gameObject.GetComponent<InteractiveObj>());
				inventoryManager.Add(iObj);
			}
		}
		
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player) {
			inventoryManager = player.GetComponent<InventoryManager> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
