using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage= 0;
    Health health;

    private void Start()
    {
        health= GetComponent<Health>();
    }
    public int GetDamage()
    {
        
        return damage;
    }

    public void Hit()
    {
        if(gameObject!=null)
        {
            health.PlayEffect();
        }
        Destroy(gameObject);
    }
}
