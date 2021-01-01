using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public PlayerController PlayerController;
    // collision on item
    void OnCollisionEnter (Collision collisionInfo) {
            // Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject.name == "Basic Motions Dummy") {
            Debug.Log("HIT!");
            // Debug.Log(PlayerController);
        }
    }
    
}
