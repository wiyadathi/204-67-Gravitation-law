using UnityEngine;

public class GravityB : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Attract(GravityB other)
    {
        Rigidbody ohterRb = other.rb;

        Vector3  direction = rb.position - ohterRb.position;
        //get distance in meter
        float distance = direction.magnitude;

        //calculate Gravity force
        float forceMagnitude = 
    }
}
