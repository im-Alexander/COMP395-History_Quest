using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Mission {
	public enum MissionStatus{
		Invalid=-1,
		Acquired=0,
		InProgress=1,
		Completed=2
	}
	public MissionStatus status;
	public List<MissionToken> tokens;

	public int points;
	public GameObject reward;
	public string displayName; //describe mission here
	public string description;

	public bool activated = false;
	public bool visable = false;

	private float count;
	private float questItems;

	public void InvokeReward(){
		Debug.Log ("In InvokeReward:reward=");
		Debug.Log (reward);
		GameObject mgrGO = GameObject.Find ("MissionManager");
		Debug.Log (reward);
		GameObject.Instantiate(reward,mgrGO.transform);
		this.status = MissionStatus.Completed;

		questItems = tokens.Count;
		count++;
		if (count >= questItems) {
			displayFinishText ();
		}
	}

	void displayFinishText(){
		Text text = reward.GetComponent ("Text") as Text;
		text.enabled = true;
	}

	void hideFinishText(){
		Text text = reward.GetComponent ("Text") as Text;
		text.enabled = false;
	}
}
