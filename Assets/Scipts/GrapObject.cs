using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapObject : MonoBehaviour
{
    public DistanceGrab distanceGrab;

    // Update is called once per frame
    void Update()
    {
        if (distanceGrab.grabbed == false)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
