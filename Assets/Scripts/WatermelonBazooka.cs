using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maura Kurp shoot watermelon script
public class WatermelonBazooka : MonoBehaviour {

    public GameObject projectile;
    public Transform muzzlePoint;

    [HideInInspector]
    public ForkController forkStuff;

    public float projectileSpeed;
    public float fireTime = 6f; //this is a constant and should not be changed
    public float timeToFire; //this will store the value in fireTime so that it can be edited
    public float projectileLifetime = 5.0f;

    void Start () {
        forkStuff = FindObjectOfType<ForkController>();
        forkStuff.playerSpotted = false;
	}
	
	void FixedUpdate () {
 //       print (forkStuff.playerSpotted);

        if (timeToFire > 0f)
        {
            timeToFire -= Time.deltaTime;
        }
        else
        {
            if (forkStuff.playerSpotted)
            {
                print("it's alive");
                SpawnProjectile();
                timeToFire = fireTime;
            }
        }
    }

    void SpawnProjectile()
    {
        GameObject spawnedProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * projectileSpeed);
        Destroy(spawnedProjectile, projectileLifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision works");
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ReduceHealth(50);
            Debug.Log("reduced health?");
        }
    }
}
