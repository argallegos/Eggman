using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex Gallegos Gun aiming script

public class GunPointTowards : MonoBehaviour {

    public GameObject player;
    PlayerScript pScript;

	// Use this for initialization
	void Start () {
        pScript = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(pScript.aimPoint);

    }
}
