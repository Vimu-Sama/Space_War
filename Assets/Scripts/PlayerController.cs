using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 inpuut;
    [SerializeField] float movespeed=1f;
    [SerializeField] float top_padding=0f;
    [SerializeField] float bottom_padding = 0f;
    [SerializeField] float left_padding = 0f;
    [SerializeField] float right_padding = 0f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet_pos;
    Vector2 lower_limit, upper_limit;

    private void Start()
    {
        set_bounds();
    }
    private void Update()
    {
        Vector2 delta = inpuut * Time.deltaTime * movespeed;
        Vector2 newpos= new Vector2();
        newpos.x = Mathf.Clamp(transform.position.x+ delta.x, lower_limit.x + left_padding, upper_limit.x - right_padding);
        newpos.y = Mathf.Clamp(transform.position.y + delta.y, lower_limit.y + bottom_padding, upper_limit.y - top_padding);
        transform.position = newpos  ;
    }
    
    void set_bounds()
    {
        Camera cam = Camera.main;
        lower_limit = cam.ViewportToWorldPoint(new Vector2(0,0));
        upper_limit = cam.ViewportToWorldPoint(new Vector2(1, 1));

    }

    void OnMove(InputValue value)
    {
        inpuut= value.Get<Vector2>();
    }


    void OnFire(InputValue value)
    {
        //Debug.Log(bullet_pos.transform);
        if(value.isPressed)
        {

            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y+1,transform.position.z), Quaternion.identity);
        }
    }

}
