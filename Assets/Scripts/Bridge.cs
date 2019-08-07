using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public EdgeCollider2D[] blocks;
    public float Delay;
    float counter;
    public GameObject DeathEffect;
    bool blowing;
    int i;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        blocks = GetComponentsInChildren<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blowing) return;
        if(counter <= 0)
        {
            Destroy(blocks[i].gameObject);
            Instantiate(DeathEffect, blocks[i].gameObject.transform.position, blocks[i].gameObject.transform.rotation);
            i++;
            counter = Delay;            
        } else
        {
            counter -= Time.deltaTime;
        }
        if (i == blocks.Length) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") blowing = true;
    }
}
