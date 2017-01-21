using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Rigidbody2D myRigidbody;
    public float movespeed;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddRelativeForce(Vector2.up * movespeed, ForceMode2D.Impulse);
	}
	
	void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
