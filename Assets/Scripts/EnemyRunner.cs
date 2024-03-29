﻿using UnityEngine;
using System.Collections;

public class EnemyRunner : MonoBehaviour {

    private bool onGround;
    public Transform groundSensor;

    private bool cliffAhead;
    public Transform cliffSensor;

    public LayerMask ground;

    private Rigidbody2D myBody;
    private Animator myAnimator;

    public float moveSpeed;
    public float jumpHeight;

    private bool reacted;

    bool isActive;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}

    void OnBecameVisible()
    {
        isActive = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isActive) return;
        onGround = Physics2D.OverlapCircle(groundSensor.position, 0.1f, ground);    // На земле ли
        cliffAhead = !Physics2D.OverlapCircle(cliffSensor.position, 0.1f, ground);  // есть ли впереди обрыв

        // Отреагировать на обрыв
        if(onGround && cliffAhead && !reacted)
        {
            ReactToCliff(Random.Range(0,3));
        }
        if (onGround && !cliffAhead && reacted)
        {
            reacted = false;
        }
        
        // Двигаться
        myBody.velocity = new Vector2(moveSpeed * transform.localScale.x, myBody.velocity.y);
        myAnimator.SetBool("OnGround", onGround);
    }

    // реакция на обрыв
    void ReactToCliff(float r)
    {
        if(r == 0)  // Прыгнуть
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);            
        }
        if (r == 1) // Упасть
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight/3);            
        }
        if (r > 1)  // Развернуться
        {
            myBody.velocity = new Vector2(0, myBody.velocity.y);
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
        reacted = true;
    }
}
