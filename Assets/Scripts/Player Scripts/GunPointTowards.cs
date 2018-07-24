using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex Gallegos Gun aiming script

public class GunPointTowards : MonoBehaviour {

    public GameObject player;
    PlayerScript pScript;
    
	void Start () {
        pScript = player.GetComponent<PlayerScript>();
	}
	
	void Update () {
        transform.LookAt(pScript.aimPoint);
    }
}
