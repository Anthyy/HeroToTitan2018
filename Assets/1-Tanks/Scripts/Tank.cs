using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // Allows you to use sliders

namespace Tanks
{
    public class Tank : MonoBehaviour
    {
        public float speed = 20f; // Travel distance over time
        public float moveDuration = 2f; // Time allowed for movement
        [Header("Bullets")]
        public float bulletSpeed = 10f; // Speed to send bullet traveling
        public GameObject bulletPrefab; // Original copy of bullet
        [Header("Explosion")]
        public float explosionForce = 5f; // Force of explosion
        public GameObject[] spawnParts; // Parts to spawn when exploding (instantiating each piece to mimic destruction)
        public Transform[] bodyParts; // Locations to spawn parts
        [Header("Fuel UI")]
        public Transform fuelSliderParent; // The parent of the UI Canvas
        public GameObject fuelSliderPrefab; // The slider prefab to spawn to UI Canvas
        public Vector2 offset = new Vector2(0, 2f); // Position of the fuel slider
        [Header("References")]
        public Transform gun; // Reference to gun for rotating the turret
        public Transform spawnPoint; // Transform point to spawn the bullet
        [Header("Components")]
        public Rigidbody2D rBody; // Reference to rigidbody component
        public Health health; // Reference to health component

        private float moveTimer = 0f; // Elapsed time of movement (fuel)
        private Slider fuelSlider; // Reference to newly spawned slider (UI)
        private bool isPlaying = false; // Is this tank currently playing? (the game is turn-based, like Worms)

        #region Unity Functions
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            
        }

        private void Reset()
        {
            
        }
        #endregion

        #region Custom Functions
        private void SpawnUI()
        {

        }
        private void UpdateUI()
        {

        }
        private void Move()
        {

        }
        private void Shoot()
        {

        }
        private void RotateGunToMouse() // Making it so wherever you point the mouse, the turret points in that same direction
        {

        }
        private void Explode()
        {
            // Loops through all the body parts
                // Spawns individual pieces to explode
        }
        public void Died() 
        {
            // Plays death animation
            // Explodes
        }
        #endregion
    }
}
