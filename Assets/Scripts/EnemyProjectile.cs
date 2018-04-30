using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    Rigidbody2D myRigidbody;
    public float movespeed;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddRelativeForce(Vector2.right * (movespeed + PlayerController.rapidsPicked * PlayerController.projectileSpeedKoeff), ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        if (transform.parent != null) Destroy(transform.parent.gameObject);
    }

    
}
