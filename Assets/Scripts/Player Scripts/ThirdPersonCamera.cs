using UnityEngine;
using System.Collections;
//Alex Gallegos third person camera script
public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]public Vector3 cameraOffset;
    [SerializeField]public Vector3 eggOffset;
    [SerializeField] float damping;
    public GameObject camTarget, player, gun;
    Transform cameraLookTarget, gunTF;
    PlayerScript localPlayer;

    public Vector3 offsetRef;

    private void Start()
    {
        cameraLookTarget = camTarget.transform;
        localPlayer = player.GetComponent<PlayerScript>();
        offsetRef = cameraOffset;
    }

    void LateUpdate()
    { 
        Vector3 targetPosition = cameraLookTarget.position
            + localPlayer.transform.forward * cameraOffset.z
            + localPlayer.transform.up * cameraOffset.y
            + localPlayer.transform.right * cameraOffset.x; 
            /*
                Vector3 targetPosition = cameraLookTarget.position
            + localPlayer.transform.forward * eggOffset.z
            + localPlayer.transform.up * eggOffset.y
            + localPlayer.transform.right * eggOffset.x;
            */

        //Quaternion targetRotation = cameraLookTarget.rotation;//Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraLookTarget.rotation, damping * Time.deltaTime);
        //transform.rotation = gun.transform.rotation;

        // transform.rotation = Quaternion.Lerp(transform.rotation, gun.transform.rotation, damping * Time.deltaTime);
    }
}
