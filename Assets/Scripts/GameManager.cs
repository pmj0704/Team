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
    //[HideInInspector]
    public bool TVoff = true;


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
    private Text IFText;
    [SerializeField]
    private Transform SmileObj;
    [SerializeField]
    private Material[] smileMats;

    private float second = 1;
    private float minute = 0;
    private float hour = 0;

    private bool timerReset = false;
    [SerializeField]
    private string[] inform;

    bool textOff = true;
    private void Start()
    {
        Key.KeyPos(repeatTime);
        Cursor.visible = false;
        checkWait();
        IFText.text = inform[repeatTime];
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

        }
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
        }
        else
        {
            Debug.Log("Á¾·á");
            second = 0;
            minute = 0;
            hour = 0;
            timerReset = false;
        }
        checkWait();
        if (Input.GetMouseButtonDown(1))
        {
            IFText.gameObject.SetActive(false);
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
        repeatTime++;
        
        movePlayer();
        fadeCamera();
        inventoryKey();
        timerReset = true;
        IFText.text = inform[repeatTime];
        IFText.gameObject.SetActive(false);
        Key.KeyPos(repeatTime);
        textOff = true;
        Key.inDraweBool();
        hasSpeaker = 0;
        checkEvent();
    }
    public void LoadStage()
    {
        movePlayer();
        fadeCamera();
        inventoryKey();
        timerReset = true;
        IFText.text = inform[repeatTime];
        IFText.gameObject.SetActive(false);
        Key.KeyPos(repeatTime);
        textOff = true;
        Key.inDraweBool();
        hasSpeaker = 0;
        checkEvent();
    }
    private void checkEvent()
    {
        if(repeatTime == 4)
        {
            Key.gameObject.SetActive(false);
        }
    }
    private void checkWait()
    {
        switch (repeatTime)
        {
            case 2:
            case 3:
            case 4:
                waitKey(15);
                break;
            default:
                return;
                break;
        }
    }

    private void waitKey(int sec)
    {
        if (second > sec && textOff && !hasKey)
        {
            IFText.gameObject.SetActive(true);
            Debug.Log(repeatTime);
            textOff = false;
        }
        else if(!(second > sec) || hasKey)
        {
            IFText.gameObject.SetActive(false);
        }
    }
}
