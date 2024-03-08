using System;
using Mirror;
using UnityEngine;

namespace _Scripts
{
    public class PlayerMovement : NetworkBehaviour
    {

        public float moveSpeed = 5f;

        public Rigidbody2D rb;
        public Camera cam;
    
        private Vector2 _movement;
        private Vector2 _mousePos;
        private Vector2 _lookDir;
        private float _lookAngle;

        private void Awake()
        {
            cam = FindObjectOfType<Camera>();
        }

        private void HandleMovement()
        {
            if (isLocalPlayer)
            {
                _movement.x = Input.GetAxis("Horizontal");
                _movement.y = Input.GetAxis("Vertical");
                rb.MovePosition(rb.position + _movement.normalized * (moveSpeed * Time.fixedDeltaTime));
            }
        }

        private void FindMousePosition()
        {
            _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        private void SetLookDirection()
        {
            _lookDir = _mousePos - rb.position;
            _lookAngle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = _lookAngle;
        }

        private void Update()
        {
            FindMousePosition();
            HandleMovement();
        }

        private void FixedUpdate()
        {
            
            SetLookDirection();
        }
    }
}
