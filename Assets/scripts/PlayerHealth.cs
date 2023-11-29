using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;

    public Slider healthSlider; //slider do wyœwietlania HP na ekranie
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart"))
        {
            GainHealth(10);

            Destroy(collision.gameObject);
        }
    }

    public void TakeDamge(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            EndGame();
        }

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / 100;
    }
    void GainHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();  
    }
    void EndGame()
    {
        SceneManager.LoadScene("Przegra³eœ");
    }
}
