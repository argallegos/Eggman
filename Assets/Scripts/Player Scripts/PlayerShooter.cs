using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    [SerializeField] float rateOfFire;

    public Transform muzzle;

    float fireDelay;
    bool canFire;

    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
    }

    public virtual void Fire()
    {
        canFire = false;

        if (Time.time < fireDelay)
            return;

        canFire = true;

    }

}
