using UnityEngine;
using System.Collections;

public class ProjectileSpreadShell : MonoBehaviour {

    public GameObject projectile;
    public float range;
    private Vector3 rot;

	// Use this for initialization
	void Start () {
        rot = transform.localEulerAngles;

        if(FindObjectsOfType<Projectile>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z));
        }
        if (FindObjectsOfType<Projectile>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z - range));
        }
        if (FindObjectsOfType<Projectile>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z + range));
        }
        if (FindObjectsOfType<Projectile>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z - range*2));
        }
        if (FindObjectsOfType<Projectile>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(rot.x, rot.y, rot.z + range*2));
        }
        Destroy(gameObject);
    }
	
	
}
