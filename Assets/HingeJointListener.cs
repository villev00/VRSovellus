using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HingeJointListener : MonoBehaviour
{
    // Kulmaerotusraja, joka laukaisee rajoituksen saavuttamisen
    public float angleBetweenThreshold = 1f;
    // Nivelliitoksen tila: joko saavutettu minimi tai maksimi, tai ei mit‰‰n, jos v‰liss‰
    public HingeJointState hingeJointState = HingeJointState.None;

 
    public UnityEvent OnMinLimitReached;
   
    public UnityEvent OnMaxLimitReached;

    public GameObject objectToRotate;

    public enum HingeJointState { Min, Max, None }
    private HingeJoint hinge;

    void RotateObjectZ()
    {
        //K‰‰nt‰‰ objektin 90 astetta
        objectToRotate.transform.Rotate(0, 90f, 0);
    }

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        OnMaxLimitReached.AddListener(RotateObjectZ);
    }

    private void FixedUpdate()
    {
        float angleWithMinLimit = Mathf.Abs(hinge.angle - hinge.limits.min);
        float angleWithMaxLimit = Mathf.Abs(hinge.angle - hinge.limits.max);

      //min limit
        if (angleWithMinLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Min)
                OnMinLimitReached.Invoke();

            hingeJointState = HingeJointState.Min;
        }
      //max limit
        else if (angleWithMaxLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Max)
                OnMaxLimitReached.Invoke();

            hingeJointState = HingeJointState.Max;
        }
       //ei limitti‰
        else
        {
            hingeJointState = HingeJointState.None;
        }

      
    }
}
