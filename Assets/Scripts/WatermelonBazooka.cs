using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maura Kurp shoot watermelon script
public class WatermelonBazooka : MonoBehaviour {

    public GameObject projectile;
    public Rigidbody rb;
    public Transform muzzlePoint;

    public float projectileSpeed;
    public float fireTime = 0.33f;
    public float projectileLifetime = 5.0f;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		
	}

    void SpawnProjectile()
    {
        GameObject spawnedProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
        rb.AddForce(muzzlePoint.forward * projectileSpeed);
        Destroy(projectile, projectileLifetime);
    }
}
