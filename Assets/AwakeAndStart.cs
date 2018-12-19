using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    //THESE FUNCTIONS ARE JUST THIS SCRIPT
    void Awake()
    {
        /* Only runs once.
         - The moment of OUR existance within the world (regardless of how long the world has been around be for we arrive)
         - Regardless if we are on or off (active or inactive, conscious or unconscious, enabled or disabled)
         
        if we are on (active/ conscious/ enabled) we can start our day straight away.
        if we are off (inactive/ unconscious/ disabled) we can wake up but we have to fully be conscious (enable/ active/ on) to be able to start the day
         */
        Debug.Log("I Exist in the world");
        // Basically, the stuff that's in Awake doesn't need this script to be on in order to run
    }
    void Start() // On start of THIS SCRIPT
    {
        /*Only runs once
         - the first frame that THIS script is on (active/ conscious/ enabled)
         if we are off (inactive/ unconscious/ disabled) we cant do anything as we are pretty much asleep

         */
        Debug.Log("I am On and Starting my day");

    }


}
