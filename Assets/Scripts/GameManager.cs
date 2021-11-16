using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [HideInInspector]
    public bool hasKey = false;
    [HideInInspector]
    public int hasSpeaker = 0;


    [HideInInspector]
    public int repeatTime = 0;

    public Drawer drawer;
    [SerializeField]
    private GetKey Key;
    [SerializeField]
    private GameObject getkeyImage;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private FadeCamera fadingCamera;
    [SerializeField]
    private Transform Respawn;

    [SerializeField]
    private Text timerText;

    private float second = 1;
    private float minute = 0;
    private float hour = 0;

    private bool timerReset = false;

    void Update()
    {
        if (timerReset == false)
        {
            second += Time.deltaTime;
            if(second > 59)
            {
                second = 0;
                minute++;
            }
            if(minute > 59)
            {
                minute = 0;
                hour++;
            }
            timerText.text = string.Format("{0:00} : {1:00} : {2:00}", hour, minute, second);
        }
        else
        {
            Debug.Log("Á¾·á");
            second = 0;
            minute = 0;
            hour = 0;
            timerReset = false;
        }
    }

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
        timerReset = true;
        Key.KeyPos(repeatTime);
    }
}
