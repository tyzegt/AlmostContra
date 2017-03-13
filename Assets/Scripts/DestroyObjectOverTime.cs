using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    public float timeToDie;
    
	void Update () {
        if (timeToDie <= 0)
        {
            Destroy(gameObject);
        }
        else timeToDie -= Time.deltaTime;
	}
}
