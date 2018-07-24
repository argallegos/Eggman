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

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraLookTarget.rotation, damping * Time.deltaTime);
    }
}
