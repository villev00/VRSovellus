using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CheckIfTargetsLeft : MonoBehaviour
{
    public Canvas gameOverCanvas;
    private List<GameObject> targetsInside;

    private void Start()
    {
        targetsInside = new List<GameObject>();
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Target"))
            {
                targetsInside.Add(collider.gameObject);
            }
        }
        UnityEngine.Debug.Log("Targets inside at start: " + targetsInside.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targetsInside.Add(other.gameObject);
            UnityEngine.Debug.Log("Target entered, count: " + targetsInside.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targetsInside.Remove(other.gameObject);
            UnityEngine.Debug.Log("Target exited, count: " + targetsInside.Count);
        }
    }

    private void Update()
    {
        if (targetsInside.Count == 0)
        {
            gameOverCanvas.enabled = true;
            UnityEngine.Debug.Log("Game Over!");
        }
        else
        {
            gameOverCanvas.enabled = false;
        }
    }
}


