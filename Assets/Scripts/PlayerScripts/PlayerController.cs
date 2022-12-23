using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private float movespeed = 1f;
        [SerializeField] private float top_padding = 0f;
        [SerializeField] private float bottom_padding = 0f;
        [SerializeField] private float left_padding = 0f;
        [SerializeField] private float right_padding = 0f;
        private Vector2 lower_limit, upper_limit;
        private Vector2 playerInput;
        private Vector2 playerFinalSpeed;
        private Vector2 newPos;
        private Shooter shooter;
        private void Start()
        {
            set_bounds();
            shooter = GetComponent<Shooter>();
        }
        private void Update()
        {
            playerFinalSpeed = playerInput * Time.deltaTime * movespeed;
            newPos.x = Mathf.Clamp(transform.position.x + playerFinalSpeed.x, lower_limit.x + left_padding, upper_limit.x - right_padding);
            newPos.y = Mathf.Clamp(transform.position.y + playerFinalSpeed.y, lower_limit.y + bottom_padding, upper_limit.y - top_padding);
            transform.position = newPos;
        }
        void set_bounds()
        {
            Camera cam = Camera.main;
            lower_limit = cam.ViewportToWorldPoint(new Vector2(0, 0));
            upper_limit = cam.ViewportToWorldPoint(new Vector2(1, 1));
        }
        void OnMove(InputValue value)
        {
            playerInput = value.Get<Vector2>();
        }
        void OnFire(InputValue value)
        {
            if (shooter != null)
            {
                shooter.isFiring = value.isPressed;
            }
        }

    }
}