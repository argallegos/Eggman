using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Vector3 aimOffset;

    [HideInInspector]
    public Vector3 eggPos, facingDirection, aimPoint, crosshairPos;
    [HideInInspector]
    public bool eggMode, inAir;
    [HideInInspector]
    public float pInputVertical, pInputHorizontal;

    Rigidbody legRB;
    Rigidbody eggRB;

    public Camera mainCam;

    public CameraPivot cameraPivot;

    [SerializeField] MouseInput MouseControl;

    InputController playerInput;
    PlayerShooter playerShooter;
    ThirdPersonCamera camScript;
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

    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }



    void Awake () {
        playerInput = GetComponent<InputController>();
        playerShooter = GetComponent<PlayerShooter>();
        camScript = mainCam.GetComponent<ThirdPersonCamera>();
        legRB = GetComponent<Rigidbody>();
        eggMode = false;
        eggForm.SetActive(false);
        legForm.SetActive(true);
        legRB.detectCollisions = true;
        legRB.isKinematic = false;
        eggRB = eggForm.GetComponent<Rigidbody>();

    }
	
	void Update () {

        crosshairPos = Crosshair.crosshairPos;
        pInputVertical = playerInput.Vertical;
        pInputHorizontal = playerInput.Horizontal;
        direction.Set(playerInput.Vertical * speed, playerInput.Horizontal * speed);

        if (!eggMode) MoveController.Move(direction);

        else
        {
            transform.position = new Vector3 (eggForm.transform.position.x, eggForm.transform.position.y, eggForm.transform.position.z);
        }

        if (playerInput.shift) EggModeTime();

        if (playerInput.jump && OnGround()) Jump();
        
        if (playerInput.shoot && !eggMode) playerShooter.Fire();

        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(crosshairPos);

        if (Physics.Raycast(ray, out hit))
        {
            //print("I'm looking at " + hit.transform.name);
            aimPoint = hit.point + aimOffset;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }
        else
        {
            //print("I'm looking at nothing!");
            aimPoint = Vector3.zero;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }




        eggPos = legForm.transform.position;

        Look();

	}

    void Look()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
        cameraPivot.SetRotation(mouseInput.y * MouseControl.Sensitivity.y);
    }

    void Jump()
    {
        legRB.AddForce(Vector3.up * jumpForce);
    }

    private bool OnGround()
    {
        return Physics.Raycast(transform.position + new Vector3(0, .1f, 0), Vector3.down, .4f);
    }

    void EggModeTime()
    {
        //ACTIVATE LEG MODE
        if (eggMode == true) {
            eggMode = false;
            eggForm.SetActive(false);
            legForm.SetActive(true);
            legRB.detectCollisions = true;
            legRB.isKinematic = false;
            camScript.cameraOffset = camScript.offsetRef;
        }
        // ACTIVATE EGG MODE
        else {
            eggMode = true;
            eggForm.SetActive(true);
            legForm.SetActive(false);
            legRB.detectCollisions = false;
            legRB.isKinematic = true;
            facingDirection = mainCam.transform.forward;

            eggRB.velocity = Vector3.zero;
            eggRB.angularVelocity = Vector3.zero;
            eggForm.transform.position = new Vector3 (transform.position.x, transform.position.y +1f, transform.position.z);
            eggForm.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            camScript.cameraOffset = camScript.eggOffset;

        }
    }

}
