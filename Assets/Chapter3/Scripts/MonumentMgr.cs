using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentMgr : MonoBehaviour {
	List<GameObject> mountPoints;


	public void attachObjToMountPoint(GameObject go, int index){
		GameObject newGO = Instantiate (go
			, mountPoints [index].transform.position
			, mountPoints [index].transform.rotation);

		newGO.SetActive (true);
		newGO.transform.parent = mountPoints [index].transform;
		newGO.transform.localPosition = Vector3.zero;
		newGO.transform.localEulerAngles = Vector3.zero;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
