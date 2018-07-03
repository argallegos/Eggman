using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour {

    public float speed = 1;
    public float jumpForce;
    public bool eggform = false;


    Rigidbody _myRB;

	void Start () {
        _myRB = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (eggform == false) {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                _myRB.velocity = new Vector3(_myRB.velocity.x, _myRB.velocity.y, speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                _myRB.velocity = new Vector3(_myRB.velocity.x, _myRB.velocity.y, -speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _myRB.velocity = new Vector3(-speed, _myRB.velocity.y, _myRB.velocity.z);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _myRB.velocity = new Vector3(speed, _myRB.velocity.y, _myRB.velocity.z);
            }

            if (Input.GetKeyDown(KeyCode.Space) && OnGround())
            {
                _myRB.velocity = new Vector3(_myRB.velocity.x, jumpForce, _myRB.velocity.z);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                _myRB.velocity = new Vector3(_myRB.velocity.x, _myRB.velocity.y, speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                _myRB.velocity = new Vector3(_myRB.velocity.x, _myRB.velocity.y, -speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _myRB.velocity = new Vector3(-speed, _myRB.velocity.y, _myRB.velocity.z);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _myRB.velocity = new Vector3(speed, _myRB.velocity.y, _myRB.velocity.z);
            }

        }

	}
    private bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, .51f);
    }
}
