using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowEgg : MonoBehaviour {

    public GameObject egg;
    public Vector3 offset;
    public Vector3 eggPos;

	// Use this for initialization
	void Start () {
     //  eggPos.Set(0f, 1f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position = new Vector3(egg.transform.localPosition.x, 0f, egg.transform.localPosition.z) + offset;
	}
}
