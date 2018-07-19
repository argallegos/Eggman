using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maura Kurp shoot watermelon script
public class WatermelonBazooka : MonoBehaviour {

    public GameObject projectile;
    private Rigidbody rb;
    public Transform muzzlePoint;

    [HideInInspector]
    public ForkController forkStuff;

    public float projectileSpeed;
    public float fireTime = 0.33f;
    public float projectileLifetime = 5.0f;

    void Start () {
        rb = GetComponent<Rigidbody>();
        forkStuff = FindObjectOfType<ForkController>();
        forkStuff.playerSpotted = false;
	}
	
	void Update () {
        print (forkStuff.playerSpotted);
		if(forkStuff.playerSpotted)
        {
            print("it's alive");
            SpawnProjectile();
        }
	}

    void SpawnProjectile()
    {
        GameObject spawnedProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
        rb.AddForce(muzzlePoint.forward * projectileSpeed);
        Destroy(projectile, projectileLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
