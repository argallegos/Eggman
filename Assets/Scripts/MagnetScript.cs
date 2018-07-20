using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Maura Kurp magnet follow script

public class MagnetScript : MonoBehaviour {

    public GameObject player;
    public float speed; //magnet speed
    public float magneticPull; //speed that the player is pulled toward magnet
    public float playerRange; //distance until magnet chases player
    public float magnetEffectRange; //the range of the magnet to begin affecting player movement

    private float step;

    private bool playerInRange; //is the player in range?
    private bool magnetEffect; //is the player in the magnet effect range?
    private bool playerSpotted;

	void Start () {
	}

    void Update()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);


    }

    void OnTriggerStay(Collider other)
    {
        StartCoroutine("PullPlayer");
        playerSpotted = true;
    }

    IEnumerator PullPlayer()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, -(magneticPull) * Time.deltaTime);
        yield return new WaitForSeconds(5f);
    }
}
