﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : GazeableButtons
{
    [SerializeField]
    private InputMode mode;

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);
        if(parentPanel.currentActiveButton!=null)
        {
            Player.instance.activeMode = InputMode.NONE;
        }        
    }
}