using System.Collections;
using UnityEngine;
public class Health : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private int scoreOnDestroy = 10;
    private CameraShake cameraShakeScript;
    private AudioPlayer audioPlayer;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    private void Start()
    {
        cameraShakeScript = FindObjectOfType<CameraShake>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        audioPlayer = AudioPlayer.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();

        if (damage != null)
        {
            TakeDamage(damage.GetDamage());
            damage.Hit();
        }
    }

    void TakeDamage(int damageGiven)
    {
        if (gameObject.tag == "Player")
        {
            cameraShakeScript.ShakeCamera();
        }
        PlayEffect();
        if (health <= damageGiven)
        {
            health = 0;
            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
            audioPlayer.PlaySoundFor("destroy", gameObject.layer);
            ScoreKeeper scoreKeeper = ScoreKeeper.Instance;
            if (scoreKeeper != null && tag != "Player")
            {
                scoreKeeper.UpdateScore(scoreOnDestroy);
            }

            StartCoroutine(DestroyForReal());
        }

        else
            health -= damageGiven;
    }

    public void PlayEffect()
    {
        if (particleSystem != null)
        {
            ParticleSystem instance = Instantiate(particleSystem, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }

    IEnumerator DestroyForReal()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject, 1);
    }


    public int GetHealth()
    {
        return health;
    }

}
