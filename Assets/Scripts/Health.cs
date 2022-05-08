using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] int scoreOnDestroy= 10;
    CameraShake cameraShakeScript;

    private void Start()
    {
        cameraShakeScript = FindObjectOfType<CameraShake>();
    }

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
        if(gameObject.tag == "Player")
        {
            cameraShakeScript.ShakeCamera();
        }
        PlayEffect();
        if (health <= damageGiven)
        {
            health = 0;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Shooter>().enabled = false;
            AudioPlayer player = FindObjectOfType<AudioPlayer>();
            player.PlaySoundFor("destroy", gameObject.layer);

            ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
            if(scoreKeeper!=null && tag!="Player")
            {
                scoreKeeper.UpdateScore(scoreOnDestroy);
                Debug.Log(scoreKeeper.GetScore());
            }
            
            StartCoroutine(DestroyForReal());
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

    IEnumerator DestroyForReal()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


    public int GetHealth()
    {
        return health;
    }

}
