using UnityEngine;

public class BackGroundScroll : GenericSingleton<BackGroundScroll>
{
    [Header("BackGround Variables")]
    [SerializeField] private float moveSpeed = 1f;

    private Material material;
    protected override void Awake()
    {
        base.Awake();
        material = GetComponent<SpriteRenderer>().material;
    }


    void Update()
    {
        material.mainTextureOffset += new Vector2(0, moveSpeed * Time.deltaTime);
    }
}
