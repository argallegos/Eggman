using UnityEngine;
using System.Collections;
//Alex Gallegos third person camera script
public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;
    public GameObject camTarget;
    public GameObject player;
    Transform cameraLookTarget;
    PlayerScript localPlayer;

    private void Start()
    {
        cameraLookTarget = camTarget.transform;
        localPlayer = player.GetComponent<PlayerScript>();
    }

    void Update () {
        Vector3 targetPosition = cameraLookTarget.position 
            + localPlayer.transform.forward * cameraOffset.z 
            + localPlayer.transform.up * cameraOffset.y
            + localPlayer.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
        
		
	}
    public void SetRotation (float amount)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x * amount, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
