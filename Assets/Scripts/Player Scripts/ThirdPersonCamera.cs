using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;
    Transform cameraLookTarget;
    PlayerScript localPlayer;

	void Awake () {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined; ;
		
	}

    void HandleOnLocalPlayerJoined (PlayerScript player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");

        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }
	
	void Update () {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
            localPlayer.transform.up * cameraOffset.y +
            localPlayer.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
        
		
	}
}
