using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos Egg mode roll script
public class EggModeRoll : MonoBehaviour {

    Rigidbody myRB;
    public GameObject player;

    void Start() {
        myRB = GetComponent<Rigidbody>();
        //GameObject player = GameObject.Find("Player");
       // PlayerScript pScript = player.GetComponent<PlayerScript>();
    }

    void Update () {
       // Quaternion rotation = Quaternion.Euler(pScript.pInputVertical, 0f, pScript.pInputHorizontal);
       // transform.rotation = rotation;


       // Vector3 velocity = new Vector3(myRB.velocity.x, myRB.velocity.y, pScript.speed);
       // myRB.AddForce(velocity);

    }
}
