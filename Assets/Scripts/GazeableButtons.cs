using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GazeableButtons : GazeableObjects
{
    protected VRCanvas parentPanel;

    private void Start()
    {
        parentPanel = GetComponentInParent<VRCanvas>();
    }

    public void SetButtonColor(Color buttonColor)
    {
        GetComponent<Image>().color = buttonColor;
    }

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        if (parentPanel != null)
        {
            parentPanel.SetActiveButton(this);
        }
        else
        {
            Debug.Log("Button is not a child of the parent with VR Panel component", this);
        }
    }
}