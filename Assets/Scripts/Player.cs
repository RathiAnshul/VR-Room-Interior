using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMode
{
    NONE,
    TELEPORT,
    WALK,
    RANDOM
}

public class Player : MonoBehaviour
{
    public static Player instance;
    public InputMode activeMode = InputMode.NONE;

    private void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(instance.gameObject);
        }
        instance = this;
    }
}