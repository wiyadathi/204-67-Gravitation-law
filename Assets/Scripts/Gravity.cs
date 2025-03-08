using NUnit.Framework;
using System.Collections.Generic; //for List
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f; //Gravitational Constant 6.674

    //create a List of objects in the galaxy to attract
    public static List<Gravity> otherObjectsList;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //create a list for the first time
        if (otherObjectsList == null)
        {
            otherObjectsList = new List<Gravity>();
        }

        //add object (with gravity script) to attract to the list
        otherObjectsList.Add(this);

    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObjectsList) 
        {
            //do not attract itself
            if (obj != this)
            {
                Attract(obj);
            }
        }

    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        //get direction between 2 objects
        Vector3 direction = rb.position - otherRb.position;

        //get only distance between 2 obj
        float distance = direction.magnitude;

        //if 2 obj are at the same position,just return=do nothing to avoid collision
        if (distance == 0f) { return; }

        //calculate gravitational force between objs
        //F = G*((m1*m2)/r*r)
        float forceMagnitude = G * (rb.mass * otherRb.mass)/Mathf.Pow(distance, 2);

        //Combine force magnitude with its direction (normalize)
        //to form final gravitaional force (Vector3)
        Vector3 gravityForce = forceMagnitude * direction.normalized;

        //apply gravitation force to other obj
        otherRb.AddForce(gravityForce);

        //finally call this method in FixedUpdate
    }
}
