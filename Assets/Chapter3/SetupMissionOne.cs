using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupMissionOne : MonoBehaviour {
	public List<GameObject> flagPrefabsAll;
	public List<GameObject> flagPrefabsAllBackup;
	public List<GameObject> flagPrefabsMission;

	public List<GameObject> spawnPointsAll;
	public List<GameObject> spawnPointsBackup;
	public List<GameObject> spawnPointsMission;

	// Use this for initialization
	void Start () {
		GameObject flagLocators = GameObject.Find ("FlagLocators");

		//Transform[] transforms = flagLocators.GetComponentInChildren<Transform> ();
		//GameObject[] goChildsGOs = flagLocators.GetComponentInChildren<GameObject> ();
		//spawnPointsAll=GameObject.FindGameObjectsWithTag("

		MissionMgr missionMgr =GameObject.Find("MissionManager").GetComponent<MissionMgr>();
		Mission m = missionMgr.missions [0];
		m.activated = true;
		m.visable = true;
		m.status = Mission.MissionStatus.Acquired;
		m.displayName = "MissionOne";
		m.description = "Collect all 5 randomly placed flags";

		//Vector3 flagPos = spawnPointsMission [0].transform.position;
		//GameObject flagInstance=(GameObject)Instantiate(
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
