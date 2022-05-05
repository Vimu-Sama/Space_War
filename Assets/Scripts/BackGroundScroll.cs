using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [Header("BackGround Variables")]
    [SerializeField] float moveSpeed = 1f;
    Vector2 offset;

    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        offset= material.mainTextureOffset;
    }

    
    void Update()
    {
        material.mainTextureOffset += new Vector2(0, moveSpeed* Time.deltaTime) ;
    }
}
