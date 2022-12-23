using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<Laser>())
        {
            spriteRenderer.enabled = false;
            capsuleCollider2D.enabled = false; 
            StartCoroutine(DestroyLater());
        }
    }

    IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }
}
