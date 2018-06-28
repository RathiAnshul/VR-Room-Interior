using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour
{
    public GazeableButtons currentActiveButton;

    public Color unselectedColor = Color.white;
    public Color selectedColor = Color.green;

    public void SetActiveButton(GazeableButtons activeButton)
    {
        if (currentActiveButton != null)
        {
            currentActiveButton.SetButtonColor(unselectedColor);
        }
        if (activeButton != null && currentActiveButton != activeButton)
        {
            currentActiveButton = activeButton;
            currentActiveButton.SetButtonColor(selectedColor);
        }
        else
        {
            Debug.Log("Resetting");
            currentActiveButton = null;
            Player.instance.activeMode = InputMode.NONE;
        }
    }
}