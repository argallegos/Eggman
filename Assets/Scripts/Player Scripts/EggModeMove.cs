using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos Egg mode roll script
public class EggModeMove : MonoBehaviour {

    Rigidbody myRB;
    public GameObject player;
    InputController playerInput;
    PlayerScript pScript;
    public float force;
    Vector3 facingDirection;

    void OnEnable() {
        myRB = GetComponent<Rigidbody>();
        playerInput = PlayerManager.Instance.InputController;
        pScript = player.GetComponent<PlayerScript>();
        facingDirection = transform.forward;
    }

    void Update () {

        Vector3 eggForce = new Vector3(pScript.pInputHorizontal, 0f, pScript.pInputVertical * force);
        myRB.AddForce(eggForce + facingDirection);
        print(facingDirection);

    }

    void ModeTest()
    {
        print("IM CHECKING IF IM AN EGG");
        if (pScript.eggMode == true)
        {
            print("I'm an egg!");
        }
        else
        {
            print("I've got legs!");
        }

    }
}
