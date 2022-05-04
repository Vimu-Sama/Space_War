using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    [SerializeField] ParticleSystem particleSystem;

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
        PlayEffect();
        if (health <= damageGiven)
        {
            health = 0;
            
            Destroy(gameObject);

        }
            
        else
            health -= damageGiven;
    }
    
    public void PlayEffect()
    {
        if(particleSystem!=null)
        {
            ParticleSystem instance = Instantiate(particleSystem, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }

}
