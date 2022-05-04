using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();
        
        if(damage != null)
        {
            TakeDamage(damage.GetDamage());
            damage.Hit();
        }
    }
    
    void TakeDamage(int damageGiven)
    {
        if (health <= damageGiven)
        {
            health = 0;
            Destroy(gameObject);
        }
            
        else
            health -= damageGiven;
    }
    
}
