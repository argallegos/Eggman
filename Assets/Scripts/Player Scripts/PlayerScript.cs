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
    [SerializeField] MouseInput MouseControl;

    InputController playerInput;
    Vector2 mouseInput;

    public Vector2 direction;
    public float pInputVertical;
    public float pInputHorizontal;

    public InputController inputController;

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

    }
	
	// Update is called once per frame
	void Update () {
       // pInputVertical = playerInput.Vertical;
        //pInputHorizontal = playerInput.Horizontal;
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

	}
}
