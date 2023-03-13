using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DistanceGrab : MonoBehaviour
{
    public InputActionReference zAxis;

    public bool grabbed = false;

    public float maxRayLenght = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float value = zAxis.action.ReadValue<float>();

        if (value > 0.5f)
        {
            RaycastHit hit;

            Ray ray = new Ray(transform.position, transform.forward);

            Vector3 rayEnd = transform.position + (transform.forward * maxRayLenght);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("GrabObject"))
            {
                hit.transform.position = rayEnd;
                //Est‰‰ objektin kiihtymisen
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                grabbed = true;
            }
            else
            {
                grabbed = false;
            }
        }
        else
        {
            grabbed = false;
        }
    }
}
