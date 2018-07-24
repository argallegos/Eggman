using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alex Gallegos Player Shooter Script
public class PlayerShooter : MonoBehaviour {

    [SerializeField] float rateOfFire;
    [SerializeField] PlayerBullet bullet;

    public Transform muzzleLeft;
    public Transform muzzleRight;

    float fireDelay;
    bool canFire;

    public virtual void Fire()
    {
        canFire = false;

        if (Time.time < fireDelay)
            return;

        fireDelay = Time.time + rateOfFire;

        Instantiate(bullet, muzzleLeft.position, muzzleLeft.rotation);
        Instantiate(bullet, muzzleRight.position, muzzleRight.rotation);

        canFire = true;

    }

}
