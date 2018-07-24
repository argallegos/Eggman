using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos Egg mode roll script
public class EggModeMove : MonoBehaviour {

    Rigidbody myRB;
    public GameObject player;
    public InputController playerInput;
    PlayerScript pScript;
    public float force;

    void OnEnable() {
        myRB = GetComponent<Rigidbody>();
        playerInput = player.GetComponent<InputController>();
        pScript = player.GetComponent<PlayerScript>();
    }

    void Update () {
        Vector3 facingDirection = new Vector3(pScript.facingDirection.x, 0f, pScript.facingDirection.z);
        myRB.AddForce(facingDirection * force * playerInput.Vertical);
    }

}
