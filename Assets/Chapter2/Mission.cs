using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void InvokeReward(){
		Debug.Log ("In InvokeReward:reward=");
		Debug.Log (reward);
		GameObject mgrGO = GameObject.Find ("MissionManager");
		Debug.Log (reward);
		GameObject.Instantiate(reward,mgrGO.transform);
		this.status = MissionStatus.Completed;
	}


}
