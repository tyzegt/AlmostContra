using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBarrelTrigger : MonoBehaviour {

    public GameObject barrel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            barrel.GetComponent<FlyingBarrel>().y = transform.position.y;
            barrel.GetComponent<FlyingBarrel>().Activate();
        }
    }

    // Use this for initialization
            void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
