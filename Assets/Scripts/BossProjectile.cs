using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float movespeed;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        var speed = Random.Range(-4, 4) + movespeed;

        myRigidbody.AddRelativeForce(Vector2.left * (speed + PlayerController.rapidsPicked * PlayerController.projectileSpeedKoeff), ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        if (transform.parent != null) Destroy(transform.parent.gameObject);
    }
}
