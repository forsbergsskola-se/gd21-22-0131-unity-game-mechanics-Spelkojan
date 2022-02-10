using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AirPlaneHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent onDeath;
    
    public int maxHealth = 5;
    public int currentHealth;

    public Healthbar healthBar;
  
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        
        if (currentHealth <= 0)
        {
          Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            DamagePlayer(1);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "InstantDeath")
        {
            DamagePlayer(10);
            Destroy(col.gameObject);
        }
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
    }
    private void Die()
    {
        Destroy(this.gameObject);
        onDeath.Invoke();
    }
}
