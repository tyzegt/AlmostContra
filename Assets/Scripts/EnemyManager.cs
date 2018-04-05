using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int health;
    private int currentHealth;
    public bool invinsible;

    public GameObject deathEffectFirst;
    public GameObject deathEffectSecond;

    // Use this for initialization
    void Start () {
        invinsible = false;
        currentHealth = health;
	}
	
    // Получить урон
    public void TakeDamage()
    {
        if (invinsible) return;

        health--;
        if(health<=0)
        {
            Die();
        }
    }

    // Умереть
    public void Die()
    {
        if (deathEffectFirst != null)
        {
            Instantiate(deathEffectFirst, transform.position, transform.rotation);
        }
        if (deathEffectSecond != null)
        {
            Instantiate(deathEffectSecond, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
