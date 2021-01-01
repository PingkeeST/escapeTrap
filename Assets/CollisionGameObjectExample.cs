using UnityEngine;

public class CollisionGameObjectExample : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(0, 0, thrust, ForceMode.Impulse);
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, -thrust);
    }
}