using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
      public CharacterController controller;
        [SerializeField]private float _currentSpeed;

        public LayerMask groundMask;
    
        private Vector3 velocity;
    
    
        void Update()
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
            
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
    
            Vector3 move = transform.right * x + transform.forward * z;
    
            controller.Move(move * _currentSpeed * Time.deltaTime);
            
    
            controller.Move(velocity * Time.deltaTime);
        }
}
