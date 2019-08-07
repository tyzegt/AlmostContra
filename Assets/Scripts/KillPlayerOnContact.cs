using UnityEngine;
using System.Collections;

public class KillPlayerOnContact : MonoBehaviour {

    public bool killSelf;
    public bool KillRegardless;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(KillRegardless) FindObjectOfType<PlayerController>().invincCounter = -1;
            FindObjectOfType<PlayerController>().Death();
            if (killSelf) Destroy(gameObject);
        }

    }
}
