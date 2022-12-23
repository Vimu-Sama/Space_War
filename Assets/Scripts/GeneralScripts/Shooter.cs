using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isFiring;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletLife = 5f;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private bool isAI;
    private Coroutine fireCoroutine;
    private Rigidbody2D rb;
    private AudioPlayer audioPlayer;

    private void Start()
    {
        if (isAI == true)
        {
            isFiring = true;
        }
        audioPlayer = AudioPlayer.Instance;

    }
    private void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(ContinuousFire());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator ContinuousFire()
    {
        while (true && GetComponent<SpriteRenderer>().enabled == true)
        {
            GameObject instance = Instantiate(bullet, transform.position, Quaternion.identity);
            rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector3(0f, bulletSpeed, 0f);
            }
            PlaySound();
            Destroy(instance, bulletLife);
            if (isAI)
            {
                yield return new WaitForSeconds(Random.Range(1f, fireRate));
            }
            else
            {
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
    void PlaySound()
    {
        if (audioPlayer != null)
        {
            audioPlayer.PlaySoundFor("shoot", gameObject.layer);
        }

    }

}
