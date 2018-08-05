using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniperRegular : MonoBehaviour {

    private AngleChecker angler;
    private Animator anim;


    // Use this for initialization
    void Start () {
        angler = GetComponent<AngleChecker>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(FindObjectOfType<PlayerController>().transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        anim.SetInteger("Angle",(int) angler.checkAngle());
	}
}
