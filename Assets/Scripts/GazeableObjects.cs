using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObjects : MonoBehaviour
{
    public virtual void OnGazeEnter(RaycastHit hitInfo)
    {
        Debug.Log("Gaze Entered On" + gameObject.name);
    }

    public virtual void OnGaze(RaycastHit hitInfo)
    {
        Debug.Log("Gaze Hold On" + gameObject.name);
    }

    public virtual void OnGazeExit()
    {
        Debug.Log("Gaze Exited On" + gameObject.name);
    }

    public virtual void OnPress(RaycastHit hitInfo)
    {
        Debug.Log("Button Pressed" + gameObject.name);
    }

    public virtual void OnHold(RaycastHit hitInfo)
    {
        Debug.Log("Button Hold On" + gameObject.name);
    }

    public virtual void OnRelease(RaycastHit hitInfo)
    {
        Debug.Log("Button Released" + gameObject.name);
    }
}