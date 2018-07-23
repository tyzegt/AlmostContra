using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBunkerSpawner : MonoBehaviour {

    public Animator anim;
    bool active;
    bool done;
    public GameObject bunker;

	// Use this for initialization
	void Start () {
        active = false;
        done = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Active", active);
	}

    void OnBecameVisible()
    {
        active = true;
    }

    public void SpawnBunker()
    {
        done = true;
        if (done) Instantiate(bunker, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
