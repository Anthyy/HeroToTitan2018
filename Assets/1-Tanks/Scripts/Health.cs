using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.UI; 

namespace Tanks
{
    public class Health : MonoBehaviour
    {

        public float maxHealth = 100f;
        public UnityEvent onDeath;
        [Header("UI")]
        public Transform healthSliderParent;
        public GameObject healthSliderPrefab;
        public Vector3 offset = new Vector2(0, 1f);

        [HideInInspector] public Vector3 lastHitpoint; // The opposite of [SerializeField]. You want to hide it but still want to be able to reference it


        private float currentHealth = 100f;
        private Slider healthSlider;

        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            SpawnUI();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }

        private void OnDestroy()
        {
            // If health slider exists
            if (healthSlider)
            {
                // Destroy HealthSlider UI
                Destroy(healthSlider.gameObject);
            }
        }
        #endregion

        #region Custom Functions
        private void SpawnUI()
        {
            // Create instance of UI and attach as child to UI parent
            GameObject clone = Instantiate(healthSliderPrefab, healthSliderParent);
            // Name health, e.g. "Tank_1_Health"
            clone.name = name + "_Health";
            // Get Slider component from clone
            healthSlider = clone.GetComponent<Slider>();
        }

        private void UpdateUI()
        {
            // Convert world position to screen
            Vector3 uiPos = Camera.main.WorldToScreenPoint(transform.position + offset);
            // Update slider position
            healthSlider.transform.position = uiPos;
            // Convert health to a 0 - 1 value and update slider value
            healthSlider.value = currentHealth / maxHealth;
        }

        private void Dead()
        {
            // Invoke all events
            onDeath.Invoke();
        }

        public void TakeDamage(float damage, Vector2 hitFrom)
        {
            lastHitpoint = hitFrom; // Record last hit position
            currentHealth -= damage; // Reducing health with damage

            // If health is depleted
            if(currentHealth <= 0)
            {
                // Ya dead
                Dead();
            }
        }
        #endregion
    }
}
