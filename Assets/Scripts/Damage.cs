using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage= 0;
    Health health;
    SceneNavigation scenenavg; 
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
        if(gameObject!=null && tag!= "projectile")
        {
            health.PlayEffect();
            AudioPlayer player = FindObjectOfType<AudioPlayer>();
            player.PlaySoundFor("destroy", gameObject.layer);
            GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Shooter>().isFiring = false;
            //GetComponent<Shooter>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            health.health = 0;
            StartCoroutine(DestroyForReal());
        }
        
        
    }

    IEnumerator DestroyForReal()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
