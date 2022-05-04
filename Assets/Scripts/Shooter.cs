using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isFiring ;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f ;
    [SerializeField] float bulletLife = 5f;
    [SerializeField] float fireRate = 0.2f;
    Coroutine fireCoroutine;
    [SerializeField] bool isAI;

    private void Start()
    {
        if(isAI==true)
        {
            isFiring = true;
        }
    }
    private void Update()
    {
        Fire();
        //Debug.Log(isFiring);
    }
    void Fire()
    {
        if(isFiring && fireCoroutine==null)
        {
            fireCoroutine= StartCoroutine(ContinuousFire()) ;
        }
        else if(!isFiring && fireCoroutine!=null)
        {
            StopCoroutine(fireCoroutine);
            //Debug.Log("its working");
            fireCoroutine = null;
        }
    }

    IEnumerator ContinuousFire()
    {
        while(true)
        {
            GameObject instance= Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb= instance.GetComponent<Rigidbody2D>();   
            if(rb!=null)
            {
                rb.velocity = new Vector3(0f, bulletSpeed, 0f);
            }
            Destroy(instance, bulletLife);
            if(isAI)
            {
                yield return new WaitForSeconds(Random.Range(1f,fireRate));
            }
            else
            {
                yield return new WaitForSeconds(fireRate);
            }
            
        }
    }

}
