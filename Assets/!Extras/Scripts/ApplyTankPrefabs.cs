using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Custom
{
    public class ApplyTankPrefabs : MonoBehaviour
    {
        public Tank player1, player2;
        public Transform gun;
        public int[] partIndexPlayer1 = new int[3];
        public int[] partIndexPlayer2 = new int[3];

        private void Awake()
        {           
            // Get the data from a GameObject that we carried over (via don't destroy)
            if(GameObject.Find("ButtonHandler") != null)
            {
                CreateCharacters handler = GameObject.Find("ButtonHandler").GetComponent<CreateCharacters>();

                partIndexPlayer1 = handler.partIndexPlayer1;
                partIndexPlayer2 = handler.partIndexPlayer2;
            }
        }

        // Use this for initialization
        
        void Start()                  
        {
            #region Spawn Player 1 Tank Parts                  
            gun = Instantiate(Resources.Load("Tank_Parts/Body_"+ partIndexPlayer1[0]) as GameObject, player1.transform).transform;           
            gun = gun.GetChild(0);
            player1.gun = gun;
            Instantiate(Resources.Load("Tank_Parts/Turret_" + partIndexPlayer1[1]) as GameObject, gun);
            player1.spawnPoint = gun.GetChild(0).GetChild(0).GetChild(0).transform;
            Instantiate(Resources.Load("Tank_Parts/Track_" + partIndexPlayer1[2]) as GameObject, player1.transform);
            #endregion

            #region Spawn Player 2 Tank Parts
            gun = Instantiate(Resources.Load("Tank_Parts/Body_" + partIndexPlayer2[0]) as GameObject, player2.transform).transform;
            gun = gun.GetChild(0);
            player2.gun = gun;
            Instantiate(Resources.Load("Tank_Parts/Turret_" + partIndexPlayer2[1]) as GameObject, gun);
            player2.spawnPoint = gun.GetChild(0).GetChild(0).GetChild(0).transform;
            Instantiate(Resources.Load("Tank_Parts/Track_" + partIndexPlayer2[2]) as GameObject, player2.transform);
            #endregion
        }
    } 
}
