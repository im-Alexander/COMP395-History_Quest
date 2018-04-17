using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManegerHelper : MonoBehaviour {
	public string missionName;
	public bool setActivated;
	public bool setVisable;
	public MissionMgr missionMgr;
	// Use this for initialization
	void Start () {
		missionMgr = GameObject.Find ("MissionManager").GetComponent<MissionMgr> ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < missionMgr.missions.Count; i++) {
			Mission m = missionMgr.missions [i];
			if (m.displayName == missionName) {
				m.activated = true;
				m.visable = true;
			}
		}
	}
}
