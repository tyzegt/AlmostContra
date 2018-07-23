using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBunker : MonoBehaviour {

    private AngleChecker angler;

    public float shootDelay = 1.5f;
    private float shootDelayCounter;

    public float delay = 0.3f;
    private float delayCounter;

    private float currentAngle;
    private float angleToPlayer;

    public GameObject projectile;
    public GameObject dulo;

    private bool isActive = false;

    void Start()
    {
        angler = GetComponent<AngleChecker>();
        delayCounter = delay;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive) return;

        if (delayCounter <= 0)
        {
            delayCounter = delay;
            angleToPlayer = angler.checkAngle();
            if (angleToPlayer < 0) angleToPlayer += 360;
            currentAngle = Mathf.Round(transform.rotation.eulerAngles.z);

            if(angleToPlayer <= 180 && angleToPlayer >= 120)
            {
                if (angleToPlayer > currentAngle) transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentAngle + 30);
                if (angleToPlayer < currentAngle) transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentAngle - 30);
            }

            if (currentAngle == angleToPlayer)
            {
                Shoot();
            }

        }
        else
        {
            delayCounter -= Time.deltaTime;
        }

        shootDelayCounter -= Time.deltaTime;
    }

    void Shoot()
    {
        if (shootDelayCounter <= 0)
        {
            Instantiate(projectile, dulo.transform.position, transform.rotation);
            shootDelayCounter = shootDelay;
        }
    }

    void OnBecameVisible()
    {
        isActive = true;
    }

    void OnBecameInvisible()
    {
        isActive = false;
    }
}
