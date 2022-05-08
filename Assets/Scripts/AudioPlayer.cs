using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    
    [Header("Shooting")]
    [SerializeField] AudioClip enemyShootSound;
    [SerializeField] AudioClip playerShootSound;
    [SerializeField] [Range(0f, 1f)] float shootVolume= 1f;

    [Header("Destroy Sounds")]
    [SerializeField] AudioClip playerDestroySound;
    [SerializeField][Range(0f, 1f)] float playerDestroyVolume=1f;

    [SerializeField] AudioClip enemyDestroySound;
    [SerializeField][Range(0f, 1f)] float enemyDestroyVolume=1f;


    //7 -Player and 8-Enemy   --> Layer with name and index
    public void PlaySoundFor(string divider, int s)
    {
        AudioClip tempClip= enemyShootSound;
        float vol= 1f;
        if(divider== "shoot")
        {
            if (s == 7)
            {
                tempClip = playerShootSound;
            }
            else
            {
                tempClip = enemyShootSound;
            }
            vol = shootVolume;
        }
        else if(divider== "destroy")
        {
            if (s == 7)
            {
                tempClip = playerDestroySound;
                vol = playerDestroyVolume;
            }
            else
            {
                tempClip = enemyDestroySound;
                vol = enemyDestroyVolume;
            }

        }
       
        AudioSource.PlayClipAtPoint(tempClip, Camera.main.transform.position, shootVolume);
    }
 }
