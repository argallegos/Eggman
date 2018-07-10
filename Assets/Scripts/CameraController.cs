using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Maura Kurp camera control script
public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	}
}
