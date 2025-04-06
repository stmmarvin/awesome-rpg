using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    private float healthPoints = 100f;
    private bool isDead = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text GameOverText;

    void Start()
    {
        healthBar.maxValue = healthPoints;
        healthBar.value = healthPoints;
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
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        healthBar.value = healthPoints;
        if (healthPoints == 0)
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