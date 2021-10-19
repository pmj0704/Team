using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [HideInInspector]
    public bool hasKey = false;

    [HideInInspector]
    public int repeatTime = 0;

    public Drawer drawer;

    public Transform playerTransform;
}
