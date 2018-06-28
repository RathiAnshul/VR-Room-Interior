using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : GazeableObjects
{
    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);
        if (Player.instance.activeMode == InputMode.TELEPORT)
        {
            Vector3 destination = hitInfo.point;
            destination.y = Player.instance.transform.position.y;
            Player.instance.transform.position = destination;
        }
    }
}