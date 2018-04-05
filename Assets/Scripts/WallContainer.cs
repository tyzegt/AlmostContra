using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallContainer : MonoBehaviour {

    public Animator anim;
    private bool closed;
    private float distance;
    public float range;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("closed", closed);
        distance = transform.position.x - FindObjectOfType<PlayerController>().transform.position.x;
        closed = distance > range || distance < -range;
        GetComponent<EnemyManager>().invinsible = closed;
	}
}
