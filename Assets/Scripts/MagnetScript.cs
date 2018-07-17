using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Maura Kurp magnet follow script

public class MagnetScript : MonoBehaviour {

    public PlayerScript player;
    public float speed; //magnet speed
    public float magneticPull; //speed that the player is pulled toward magnet
    public float playerRange; //distance until magnet chases player
    public float magnetEffectRange; //the range of the magnet to begin affecting player movement

    private bool playerInRange; //is the player in range?
    private bool magnetEffect; //is the player in the magnet effect range?

	void Start () {
        player = FindObjectOfType<PlayerScript>();
	}
	
	void Update () {
        DetectPlayer();

        EnemyMoveToPlayer();
	}

    void DetectPlayer()
    {
        //Detect if the player is within the specified range
        playerInRange = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), playerRange);
        magnetEffect = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), magnetEffectRange);
    }

    void EnemyMoveToPlayer ()
    {
        //If the player is in range, the magnet will move toward them
        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed* Time.deltaTime);
        }

        //Additionally, if the magnet is close enough, it will pull in the player just a little bit
        if (magnetEffect)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, magneticPull * Time.deltaTime);
        }
    }
}
