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


    public int repeatTime = 6;

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
    private Transform Room;
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
        if(repeatTime != 11)smileMats[3].mainTexture = smileMats[4].mainTexture;
        if(repeatTime != 7)smileMats[2].mainTexture = smileMats[1].mainTexture;
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
            Debug.Log("����");
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
            case 7:
                smileMats[2].mainTexture = smileMats[0].mainTexture;
                break;
            case 8:
                smileMats[2].mainTexture = smileMats[1].mainTexture;
                break;
            case 9:
                for(int i =1; i < Room.childCount; i++)
                {
                    Room.GetChild(i).rotation = Quaternion.Euler(Room.GetChild(i).rotation.x, Room.GetChild(i).rotation.y, Room.GetChild(i).rotation.z + 90);
                }
                break;
            case 10:
                for (int i = 1; i < Room.childCount; i++)
                {
                    Room.GetChild(i).rotation = Quaternion.Euler(Room.GetChild(i).rotation.x, Room.GetChild(i).rotation.y, Room.GetChild(i).rotation.z - 90);
                }
                break;
            case 11:
                smileMats[3].mainTexture = smileMats[2].mainTexture;
                break;
            case 12:
                smileMats[3].mainTexture = smileMats[4].mainTexture;
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
