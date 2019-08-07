using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Rigidbody2D myRigidbody;
    public float movespeed;
    public float spinningSpeed;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddRelativeForce(Vector2.up * (movespeed + PlayerController.rapidsPicked*PlayerController.projectileSpeedKoeff), ForceMode2D.Impulse);
        myRigidbody.angularVelocity = spinningSpeed;
	}


    void Update()
    {
        Renderer r = GetComponent<SpriteRenderer>();
        if(!r.isVisible) Destroy(gameObject);
    }

	
	//void OnBecameInvisible()
 //   {
 //       Destroy(gameObject);
 //       if (transform.parent != null) Destroy(transform.parent.gameObject);
 //   }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            if(other.GetComponent<EnemyManager>() != null)
            {
                other.GetComponent<EnemyManager>().TakeDamage();
                Destroy(gameObject);
                if (transform.parent != null) Destroy(transform.parent.gameObject);
            }
        }
    }
}
