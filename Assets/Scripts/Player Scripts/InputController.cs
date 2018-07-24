using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos player input script
public class InputController : MonoBehaviour {

    [HideInInspector]
    public float Vertical, Horizontal;
    [HideInInspector]
    public Vector2 MouseInput;
    [HideInInspector]
    public bool shift, jump, shoot;

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        shoot = Input.GetButton("Fire1");
        shift = Input.GetKeyUp(KeyCode.LeftShift);
        jump = Input.GetKeyDown(KeyCode.Space);

    }

    }
