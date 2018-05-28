using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour
{
    public GameObject reticle;

    public Color inactiveReticleColor = Color.gray;
    public Color activeReticleColor = Color.green;

    private GazeableObjects currentGazeableObjects;
    private GazeableObjects currentSelectedObjects;
    private RaycastHit lastHit;

    void Start()
    {
        SetReticleColor(inactiveReticleColor);
    }

    void Update()
    {
        ProcessGaze();
        CheckForInput(lastHit);
    }

    public void ProcessGaze()
    {
        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);

        if (Physics.Raycast(raycastRay, out hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            GazeableObjects gazeObject = hitObject.GetComponentInParent<GazeableObjects>();
            if (gazeObject != null)
            {
                if (gazeObject != currentGazeableObjects)
                {
                    ClearCurrentGazeObjets();
                    currentGazeableObjects = gazeObject;
                    currentGazeableObjects.OnGazeEnter(hitInfo);
                    SetReticleColor(activeReticleColor);
                }
                else
                {
                    currentGazeableObjects.OnGaze(hitInfo);
                }
            }
            else
            {
                ClearCurrentGazeObjets();
            }
            lastHit = hitInfo;
        }
        else
        {
            ClearCurrentGazeObjets();
        }       
    }

    private void SetReticleColor(Color reticleColor)
    {
        reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
    }

    private void ClearCurrentGazeObjets()
    {
        if (currentGazeableObjects != null)
        {
            currentGazeableObjects.OnGazeExit();
            SetReticleColor(inactiveReticleColor);
            currentGazeableObjects = null;
        }
    }

    private void CheckForInput(RaycastHit hitInfo)
    {
        if (Input.GetMouseButtonDown(0) && currentGazeableObjects != null)
        {
            currentSelectedObjects = currentGazeableObjects;
            currentSelectedObjects.OnPress(hitInfo);
        }
        else if (Input.GetMouseButton(0) && currentGazeableObjects != null)
        {
            currentSelectedObjects.OnHold(hitInfo);
        }
        else if (Input.GetMouseButtonUp(0) && currentGazeableObjects != null)
        {
            currentSelectedObjects.OnRelease(hitInfo);
            currentGazeableObjects = null;
        }
    }
}