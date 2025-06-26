using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text GameOverText;
    [SerializeField] private float damageOnHit = 10f;

    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        GameOverText.gameObject.SetActive(false);
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        healthBar.value = currentHealth;

        Debug.Log($"Took {damage} damage. Health now: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }


    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GameOverText.gameObject.SetActive(true);
        GetComponentInChildren<Animator>().SetTrigger("die");

    }

    public bool IsDead()
    {
        return isDead;
    }

}