using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty gripAnimation;
    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float triggervalue = pinchAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggervalue);

        float gripvalue = gripAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripvalue);
    }
}
