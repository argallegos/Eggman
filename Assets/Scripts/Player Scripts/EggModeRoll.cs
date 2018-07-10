using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos Egg mode roll script
public class EggModeRoll : MonoBehaviour {

    Rigidbody myRB;
    public GameObject player;
    InputController playerInput;
    PlayerScript pScript;

    void Start() {
        myRB = GetComponent<Rigidbody>();
        playerInput = PlayerManager.Instance.InputController;
        GameObject player = GameObject.Find("Player");
        pScript = player.GetComponent<PlayerScript>();
    }

    void Update () {
       // Quaternion rotation = Quaternion.Euler(pScript.pInputVertical, 0f, pScript.pInputHorizontal);
       //transform.Rotate = playerInput.Vertical;


      transform.Rotate(pScript.pInputVertical, 0f, pScript.pInputHorizontal);
       // myRB.AddForce(velocity);

    }
}
