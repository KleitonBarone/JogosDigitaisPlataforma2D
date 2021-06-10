using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float projectileDamage = 25;
    public float currentHealth;
    private Slider lifeBar = null;
    void Start()
    {
        currentHealth = maxHealth;
        lifeBar = transform.GetComponentInChildren<Slider>();
        if (lifeBar != null)
            lifeBar.value = currentHealth / maxHealth;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile")) 
        {  
            currentHealth -= projectileDamage;
            if (lifeBar != null)
                lifeBar.value = currentHealth / maxHealth;
        }

        if(currentHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
}
