using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        public List<Tank> tanks; // List of all tanks in the game
        public int currentTank; // Index to current tank that's playing

        // Use this for initialization
        void Start()
        {
            // Find all the tanks in the game
            tanks = new List<Tank>(FindObjectsOfType<Tank>());
            // Select the first tank at the beginning of the game
            SetTank(currentTank);
        }

        public void RemoveTank(Tank tankToRemove)
        {
            // Remove the tank from this list
            tanks.Remove(tankToRemove);
            // Update the currentTank
            SetTank(currentTank);
        }
            

        // Apply the current tank
        void SetTank(int current)
        {
            // Loop through all the tanks
            for (int i = 0; i < tanks.Count; i++)
            {
                Tank tank = tanks[i]; // Get tank at index I
                tank.IsPlaying = false; // Set the tank's input to false
                // If the tank is the current one selected
                if(i == current)
                {
                    // This tank is playing now
                    tank.IsPlaying = true;
                }
            }
        }

        public void NextTank()
        {
            // Increment currenTank
            currentTank++;
            // If currentTank is outside array
            if (currentTank >= tanks.Count)
            {
                // Reset currentTank
                currentTank = 0;
            }
            // Apply the current tank selection
            SetTank(currentTank);
        }
    } 
}
