using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int health;
    private int currentHealth;

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
        Destroy(gameObject);
    }
}
