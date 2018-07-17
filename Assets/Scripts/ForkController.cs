using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkController : MonoBehaviour {

    private PlayerScript player;
    private bool playerInRange;

    public float playerRange;
    public float enemySpeed;

	void Start () {
        player = FindObjectOfType<PlayerScript>();
	}
	
	void Update () {
        playerInRange = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), playerRange);

        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
