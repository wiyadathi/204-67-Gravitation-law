using UnityEngine;

public class GravityE : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Attract(GravityE other)
    {
        Rigidbody otherRb = other.rb;

        //find distance between two objects
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 finalForce = forceMagnitude * direction.normalized;

        //addforce 
        otherRb.AddForce(finalForce);
    }
}