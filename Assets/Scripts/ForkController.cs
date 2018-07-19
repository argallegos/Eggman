using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maura Kurp enemy follow script
public class ForkController : MonoBehaviour {

    private bool playerInRange = false;
    [HideInInspector]
    public bool playerSpotted = false;

    public GameObject player;
    public Transform playerPosition;
    public float playerRange;
    public float enemySpeed;

    public float step;

	void Start () {

	}
	
	void Update () {
        Vector3 targetDir = playerPosition.position - transform.position;
        step = enemySpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        
	}

    private void OnTriggerStay(Collider other)
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        playerSpotted = true;
    }
}
