using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage = 0;
    [SerializeField] private float timeTakesToDestroy = 2f;
    private Health health;
    private WaitForSeconds waitForSeconds;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    private AudioPlayer audioPlayer;
    private void Start()
    {
        waitForSeconds = new WaitForSeconds(timeTakesToDestroy);
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (gameObject != null && tag != "projectile")
        {
            health.PlayEffect();
            audioPlayer.PlaySoundFor("destroy", gameObject.layer);
            spriteRenderer.enabled = false;
            polygonCollider2D.enabled = false;
            health.health = 0;
            StartCoroutine(DestroyForReal());
        }
    }

    IEnumerator DestroyForReal()
    {
        yield return waitForSeconds;
        Destroy(gameObject);
    }

}
