using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!= "projectile")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false; 
            StartCoroutine(DestroyLater());
        }
    }

    IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }
}
