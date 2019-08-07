using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject LeftCannon;
    public GameObject RightCannon;
    public GameObject Target;
    public GameObject Projectile;
    public float ShotDelay;
    float counterLeft;
    float counterRight;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        counterLeft = ShotDelay;
        counterRight = 0;
    }

    void OnBecameVisible()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        if (Target == null)
        {
            if (LeftCannon != null) LeftCannon.GetComponent<EnemyManager>().Die();
            if (RightCannon != null) RightCannon.GetComponent<EnemyManager>().Die();
            Destroy(gameObject);
        }

        if (LeftCannon != null)
        {
            if(counterLeft <= 0)
            {
                Instantiate(Projectile, LeftCannon.transform.position, LeftCannon.transform.rotation);
                counterLeft = ShotDelay + Random.Range(-1, 0);
            }
            else
            {
                counterLeft -= Time.deltaTime;
            }
        }
        if (RightCannon != null)
        {
            if (counterRight <= 0)
            {
                Instantiate(Projectile, RightCannon.transform.position, RightCannon.transform.rotation);
                counterRight = ShotDelay + Random.Range(-1, 0);
            }
            else
            {
                counterRight -= Time.deltaTime;
            }
        }

    }
}
