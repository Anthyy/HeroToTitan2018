﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Plugins.Controllers;

namespace SunnyLand
{
    public class Player : MonoBehaviour
    {
        public float gravity = -25f;
        public float runSpeed = 8f;
        public float groundDamping = -20f; // How fast do we change direction?
        public float inairDamping = 5f;
        public float jumpHeight = 3f;

        private Vector3 velocity; // Calculate velocity ourselves in this script

        private CharacterController2D controller;
        private Animator anim;
        private SpriteRenderer rend;

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<CharacterController2D>();
            anim = GetComponent<Animator>();
            rend = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            // If controller is grounded
            if (controller.isGrounded)
            {
                // Reset y velocity
                velocity.y = 0f;
            }

            float inputH = Input.GetAxis("Horizontal"); // Left or Right, A or D
            float inputV = Input.GetAxis("Vertical"); // Up or Down, W or S

            // If button is pressed (Horizontal)
            if(inputH != 0)
            {
                // Check what direction the sprite should be flipped
                rend.flipX = inputH < 0;
            }

            velocity.x = inputH * runSpeed; // Move horizontally

            if(controller.isGrounded && Input.GetButtonDown("Jump")) // Jump = Space
            {
                velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
            }           

            // Apply gravity
            velocity.y += gravity * Time.deltaTime; // Over time, gradually push the player down with gravity

            // One-way collision (think Mario Bros. for some of the blocks)
            if (controller.isGrounded && inputV < 0)
            {
                velocity.y *= 3f;
                controller.ignoreOneWayPlatformsThisFrame = true;
            }

            // Apply velocity to controller
            controller.Move(velocity * Time.deltaTime); // Moves the character controller

            // Grab current velocity for next frame
            velocity = controller.velocity;

            // Update the animations
            UpdateAnim();
        }

        void UpdateAnim()
        {
            // Set IsGrounded 
            anim.SetBool("IsGrounded", controller.isGrounded);

            // Update Jump
            anim.SetFloat("JumpY", controller.velocity.normalized.y);

            // Set isRunning
            anim.SetBool("IsRunning", controller.velocity.x != 0);
        }
    } 
}
