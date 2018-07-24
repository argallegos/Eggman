using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex Gallegos player bullet script

[RequireComponent(typeof(Rigidbody))]
public class PlayerBullet : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] float damage;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this);
    }

}
