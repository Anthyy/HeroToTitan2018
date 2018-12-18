using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // You can type '.SM' for short
using UnityEngine;

namespace Menu
{
    public class MenuHandler : MonoBehaviour
    {
        
        public void LoadScene(int menuID) // Stores the index number and name of the scene (for build settings)
        {
            SceneManager.LoadScene(menuID);
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    } 
}
