using UnityEngine;
using System.Collections;
//Alex Gallegos third person camera script
public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]public Vector3 cameraOffset;
    [SerializeField]public Vector3 eggOffset;
    [SerializeField] float damping;
    public GameObject camTarget, player, gun;
    Transform cameraLookTarget;
    PlayerScript localPlayer;
    public float maxAngle, minAngle;

    public Quaternion maxRotation;

    public float rotationX;


    public Vector3 offsetRef;

    private void Start()
    {
        cameraLookTarget = camTarget.transform;
        localPlayer = player.GetComponent<PlayerScript>();
        offsetRef = cameraOffset;
    }
    private void FixedUpdate()
    {
        //maxRotation.eulerAngles = new Vector3(Mathf.Clamp(cameraLookTarget.rotation.x, minAngle, maxAngle), transform.rotation.y, transform.rotation.z);
        if (cameraLookTarget.transform.eulerAngles.x > maxAngle) rotationX = maxAngle;
        
        else if (cameraLookTarget.transform.eulerAngles.x < minAngle) rotationX = minAngle;
        
        else rotationX = cameraLookTarget.transform.eulerAngles.x;
       // rotationX = cameraLookTarget.rotation.x;

        // print("maxRot = " + maxRotation);
        //maxRotation.Set(Mathf.Clamp(cameraLookTarget.rotation.x, minAngle, maxAngle), transform.rotation.y, transform.rotation.z, 1);
        //maxRotation.Set(rotationX, transform.rotation.y, transform.rotation.z, 1);
        maxRotation.eulerAngles = new Vector3(rotationX, cameraLookTarget.rotation.y, cameraLookTarget.rotation.z);

    }
    void LateUpdate()
    {

        /*
        if (cameraLookTarget.rotation.x > maxAngle)
        {
            maxRotation.eulerAngles = new Vector3(maxAngle, cameraLookTarget.rotation.y, cameraLookTarget.rotation.z);
        }
        else if (cameraLookTarget.rotation.x < minAngle)
        {
            maxRotation.eulerAngles = new Vector3(minAngle, cameraLookTarget.rotation.y, cameraLookTarget.rotation.z);
        }
        else
        {
            maxRotation = cameraLookTarget;
        }
        */

        Vector3 targetPosition = cameraLookTarget.position
            + localPlayer.transform.forward * cameraOffset.z
            + localPlayer.transform.up * cameraOffset.y
            + localPlayer.transform.right * cameraOffset.x;


        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraLookTarget.rotation, damping * Time.deltaTime);
       // print("transform = " + transform.rotation);
    }
}
