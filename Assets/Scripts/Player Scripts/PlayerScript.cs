using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos main player script
[RequireComponent(typeof(MoveController))]

public class PlayerScript : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;

    }

    public float speed, moveForce, dmgMult, jumpForce;
    public GameObject eggForm, legForm;
    public Vector2 direction;

    [HideInInspector]
    public Vector3 eggPos, mouseRotate;
    [HideInInspector]
    public bool eggMode, inAir;
    [HideInInspector]
    public float pInputVertical, pInputHorizontal;

    Rigidbody legRB;

    [SerializeField] MouseInput MouseControl;

    InputController playerInput;
    Vector2 mouseInput;

    private MoveController m_MoveController;
    public MoveController MoveController

    {
        get
        {
            if (m_MoveController == null)
                m_MoveController = GetComponent<MoveController>();
            return m_MoveController;
        }
    }

    void Awake () {
        playerInput = PlayerManager.Instance.InputController;
        PlayerManager.Instance.LocalPlayer = this;
        legRB = GetComponent<Rigidbody>();
        eggMode = false;
        eggForm.SetActive(false);
        legForm.SetActive(true);
        legRB.detectCollisions = true;
        legRB.isKinematic = false;

    }
	
	void Update () {
        pInputVertical = playerInput.Vertical * speed;
        pInputHorizontal = playerInput.Horizontal * speed;
        direction.Set(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        if (!eggMode) //legRB.AddForce(pInputHorizontal, 0f, pInputVertical * moveForce);
                        MoveController.Move(direction);
        else
        {
            transform.position = new Vector3 (eggForm.transform.position.x, transform.position.y, eggForm.transform.position.z);
        }

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);

        mouseRotate = (Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
        //print(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        eggPos = legForm.transform.position;
        if (playerInput.shift)
        {
            EggModeTime();

        }
        if (playerInput.jump && OnGround())
        {
            Jump();
        }
            

	}

    void Jump()
    {
        legRB.AddForce(Vector3.up * jumpForce);
    } 

    void EggModeTime()
    {
        if (eggMode == true) {
            eggMode = false;
            eggForm.SetActive(false);
            legForm.SetActive(true);
            legRB.detectCollisions = true;
            legRB.isKinematic = false;
        }

        else {
            eggMode = true;
            eggForm.SetActive(true);
            legForm.SetActive(false);
            legRB.detectCollisions = false;
            legRB.isKinematic = true;
            
            eggForm.transform.position = new Vector3 (transform.position.x, transform.position.y +1f, transform.position.z);
            eggForm.transform.rotation = Quaternion.identity;

        }
    }

    private bool OnGround()
    {
        return Physics.Raycast(transform.position + new Vector3(0, .1f, 0), Vector3.down, .4f);
    }

}
