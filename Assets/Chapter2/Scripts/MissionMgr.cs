using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissionMgr : MonoBehaviour {
	public List<Mission> missions; //design time part
	public List<MissionToken> missionTokens=new List<MissionToken>();//run time part

	public void Add(MissionToken mt){
		Debug.Log ("In MissionMgr.Add:");
		Debug.Log (mt);

		bool uniqueToken = true;
		for (int i = 0; i < missionTokens.Count; i++) {
			if (missionTokens [i].id == mt.id) {
				uniqueToken = false;
				break;
			}
		}
		if (uniqueToken) {
			missionTokens.Add (mt);
		}
		ValidateAll ();
	}

	bool ValidateMission(Mission m){
		bool missionComplete = true;
		//mission will be considered completed when
		//	all mission tokes are collected (are in missionTokens list)
		for (int i = 0; i < m.tokens.Count; i++) {
			//
			bool tokenFound = false;
			int id = m.tokens [i].id;
			for (int j = 0; j < missionTokens.Count; j++) {
				if (missionTokens [j].id == id) {
					tokenFound = true;
					break;
				}
			}
			if (!tokenFound) {
				missionComplete = false;	
				break;
			}
		}
		if (missionComplete) {
			m.status = Mission.MissionStatus.Completed;
		}
	
		return missionComplete;
	}

	bool ValidateMission2(Mission m){
		bool res= m.tokens.All (mt => missionTokens.Any(mt2 => mt2.id==mt.id));
		if (res) {
			m.status = Mission.MissionStatus.Completed;
		}
		return res;
	}


	void ValidateAll(){
		for (int i = 0; i < missions.Count; i++) {
			Mission m = missions [i];
			if (ValidateMission (m)) {
				m.InvokeReward ();
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
