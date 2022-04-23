using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float move_speed = 1f;

    
    private void Update()
    {
        Vector2 delta = new Vector2();
        delta.y = (transform.localPosition.y + move_speed * Time.deltaTime);
        transform.localPosition = (Vector3)delta;
    }
}
