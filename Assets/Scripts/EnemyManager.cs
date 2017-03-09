using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int health;
    private int currentHealth;

    public GameObject deathEffect;

	// Use this for initialization
	void Start () {
        currentHealth = health;
	}
	
    // Получить урон
    public void TakeDamage()
    {
        health--;
        if(health<=0)
        {
            Die();
        }
    }

    // Умереть
    public void Die()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
