using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager GameManager;
    
    // OnTriggerEnter can only be use when item have a collider
    // and isTrigger must be true
    void OnTriggerEnter ()
    {
        // you get to access the GameManager script and call its funtion
        // do remember to insert the script to the collision
        GameManager.ComplateLevel();
    }


}
