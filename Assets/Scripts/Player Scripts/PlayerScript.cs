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

    public float speed, dmgMult;
    public GameObject eggForm;
    public GameObject legForm;
    public Vector3 eggPos;
    public bool eggMode;

    Collider legCol;
    Rigidbody legRB;


    [SerializeField] MouseInput MouseControl;

    InputController playerInput;
    Vector2 mouseInput;
    public Vector3 mouseRotate;

    public Vector2 direction;
    public float pInputVertical;
    public float pInputHorizontal;

   // public InputController inputController;

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
        legCol = GetComponent<Collider>();
        legRB = GetComponent<Rigidbody>();
        eggForm.SetActive(false);
        eggMode = false;

    }
	
	void Update () {
        pInputVertical = playerInput.Vertical * speed;
        pInputHorizontal = playerInput.Horizontal * speed;
        direction.Set(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        if (!eggMode) MoveController.Move(direction);
        else
        {
            transform.position = new Vector3 (eggForm.transform.position.x, transform.position.y, eggForm.transform.position.z);
        }

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);

        mouseRotate = (Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
        //print(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        eggPos = legForm.transform.position;
        //transform.position = eggForm.transform.position;
        if (playerInput.shift)
        {
            EggModeTime();

        }

    
    
        /*
        if (playerInput.eggMode == true)
        {
            eggForm.SetActive(true);
            legForm.SetActive(false);
            transform.position = eggForm.transform.position;


        }
        else
        {
            eggForm.SetActive(false);
            legForm.SetActive(true);
            eggForm.transform.position = transform.position;
        }
        */

	}
    void EggModeTime()
    {
        if (eggMode == true) {
            eggMode = false;
            eggForm.SetActive(false);
            legForm.SetActive(true);
        }

        else {
            eggMode = true;
            eggForm.SetActive(true);
            legForm.SetActive(false);
            legCol.enabled = false;
            
            eggForm.transform.position = new Vector3 (transform.position.x, transform.position.y +1f, transform.position.z);
            eggForm.transform.rotation = Quaternion.identity;

        }
    }

}
