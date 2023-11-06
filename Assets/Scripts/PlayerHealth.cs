using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 300;
    public int currentHealth;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        // healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.slider.value -= damage;
        // healthbar.slider.value -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        // healthbar.setHealth(currentHealth);
    }
    void OnCollisionEnter(Collision collision)
    {
       
        
            TakeDamage(10);
            Debug.Log("Hit Made");
            
        
    }


}
