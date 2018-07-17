using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos player input script
public class InputController : MonoBehaviour {

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    //public bool eggMode;
    public bool shift;
    public bool jump;

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        shift = Input.GetKeyUp(KeyCode.LeftShift);
        jump = Input.GetKeyDown(KeyCode.Space);

       

    }

    }
