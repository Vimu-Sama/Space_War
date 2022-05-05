using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Camera Shake Variables")]
    [SerializeField] float shakeMagnitude = 1f;
    [SerializeField] float shakeDuration = 1;
    Vector3 initialCameraPosition;


    void Start()
    {
        initialCameraPosition = transform.position;        
    }

    public void ShakeCamera()
    {
        StartCoroutine(StartJitter());
        //transform.position = initialCameraPosition;
    }

    IEnumerator StartJitter()
    {
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialCameraPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialCameraPosition;
        
    }
}
