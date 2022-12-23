using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Camera Shake Variables")]
    [SerializeField] private float shakeMagnitude = 1f;
    [SerializeField] private float shakeDuration = 1;
    private Vector3 initialCameraPosition;
    private float elapsedTime;


    void Start()
    {
        initialCameraPosition = transform.position;
    }

    public void ShakeCamera()
    {
        StartCoroutine(StartJitter());
    }

    IEnumerator StartJitter()
    {
        elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialCameraPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialCameraPosition;

    }
}
