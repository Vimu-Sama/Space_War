using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isFiring ;
    [SerializeField] GameObject bullet;
    Coroutine fireCoroutine;



    private void Update()
    {
        Fire();
    }
    void Fire()
    {
        if(isFiring)
        {
            fireCoroutine= StartCoroutine(ContinuousFire()) ;
        }
        else
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator ContinuousFire()
    {
        while(true)
        {
            Instantiate(gameObject, transform);
        }
    }

}
