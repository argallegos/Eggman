using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    [SerializeField] float rateOfFire;
    [SerializeField] PlayerBullet bullet;

    public Transform muzzleLeft;
    public Transform muzzleRight;

    float fireDelay;
    bool canFire;

    private void Awake()
    {
       // muzzleLeft = transform.Find("muzzleLeft");
       // muzzleRight = transform.Find("muzzleRight");
    }

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
