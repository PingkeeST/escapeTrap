using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Sphere") {
            Debug.Log("Player HIT!");
            GetComponent<Animator>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            // Debug.Log(PlayerController);
        }
    }
}
