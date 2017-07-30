using UnityEngine;
using System.Collections;

public class ProjectileLaserShell : MonoBehaviour {

    public GameObject projectile;
    public float delay;
    private float delayCounter;
    public int projectilesCount;

	// Use this for initialization
	void Start () {
        Instantiate(projectile, transform.position, transform.rotation);
        projectilesCount--;
        delayCounter = delay;
	}
	
	// Update is called once per frame
	void Update () {
	    if(projectilesCount > 0 && delayCounter <=0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            projectilesCount--;
            delayCounter = delay;
        } else
        {
            delayCounter -= Time.deltaTime;
        }

        if (projectilesCount <= 0) Destroy(gameObject);
	}
}
