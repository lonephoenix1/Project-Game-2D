using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public float heartDropChance = 0.1f;
    public GameObject heart;


    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamge(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    void Die()
    {

        Destroy(gameObject, 5f);

        GenerateHeart();
    }

    void GenerateHeart()
    {
        if (Random.Range(0f, 1f) < heartDropChance && heart != null)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
    }
}
