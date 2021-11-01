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

    public bool playerAimTag;

    [SerializeField]
    private GameObject getkeyImage;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private FadeCamera fadingCamera;
    [SerializeField]
    private Transform Respawn;

    public void movePlayer()
    {
        playerTransform.position = Respawn.position;
    }
    public void fadeCamera()
    {
        fadingCamera.RedoFade();
    }
    public void inventoryKey()
    {
        getkeyImage.SetActive(hasKey);
    }
    public void NextStage()
    {
        movePlayer();
        fadeCamera();
        inventoryKey();
        repeatTime++;
    }
}
