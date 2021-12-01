using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
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
    [SerializeField]
    private Vector3[] roomPos;

    [SerializeField]
    private TMP_Text Welcome;

    private float second = 1;
    private float minute = 0;
    private float hour = 0;
    private bool timerReset = false;
    [SerializeField]
    private string[] inform;
    public Light light;
    [SerializeField]
    private Light light2;
    bool textOff = true;
    bool thirteen = true;
    private void Start()
    {
        if(repeatTime == 9)Respawn.position = roomPos[1];
        if(repeatTime == 15)Respawn.position = roomPos[2];

        playerTransform.position = Respawn.position;
        if(repeatTime != 11)smileMats[3].mainTexture = smileMats[4].mainTexture;
        if(repeatTime != 7)smileMats[2].mainTexture = smileMats[1].mainTexture;
        if (repeatTime != 11) smileMats[3].mainTexture = smileMats[4].mainTexture;
        if (repeatTime != 7) smileMats[2].mainTexture = smileMats[1].mainTexture;
        Key.KeyPos(repeatTime);
        Cursor.visible = false;
        checkWait();
        IFText.text = inform[repeatTime];
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("UI");
            Cursor.visible = true;
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
        if(repeatTime == 4 || repeatTime == 12)
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
                waitKey(15);
                smileMats[2].mainTexture = smileMats[0].mainTexture;
                break;
            case 8:
                waitKey(15);
                smileMats[2].mainTexture = smileMats[1].mainTexture;
                break;
            case 9:
                waitKey(15);
                Respawn.position = roomPos[1];
                break;
            case 10:
                waitKey(15);
                Respawn.position = roomPos[0];
                break;
            case 11:
                waitKey(15);
                smileMats[3].mainTexture = smileMats[2].mainTexture;
                break;
            case 12:
                waitKey(15);
                smileMats[3].mainTexture = smileMats[4].mainTexture;
                break;
            case 13:
                waitKey(15);
                if (thirteen)
                {
                    light.color = Color.black;
                    TVoff = false;
                    thirteen = false;
                    Welcome.text = "Escape";
                }
                break;
            case 14:
                waitKey(15);
                StartCoroutine(RedLight());
                Welcome.text = "Welcome";
                break;
            case 15:
                Respawn.position = roomPos[2];
                break;
            case 16:
                Respawn.position = roomPos[0];
                StartCoroutine(room2());
                break;
            default:
                break;
        }
    }
    private IEnumerator RedLight()
    {
        if (!thirteen)
        {
            light.color = Color.red;
            yield return new WaitForSeconds(.3f);
            light.color = Color.white;
            yield return new WaitForSeconds(.3f);
            light.color = Color.red;
            yield return new WaitForSeconds(.3f);
            light.color = Color.white;
            yield return new WaitForSeconds(.3f);
            light.color = Color.red;
            yield return new WaitForSeconds(.3f);
            light.color = Color.white;
            yield return new WaitForSeconds(.3f);
            thirteen = true;
        }
    }

    private IEnumerator room2()
    {
        if (thirteen)
        {
            yield return new WaitForSeconds(5f);
            light2.gameObject.SetActive(true);
            thirteen = false;
        }
    }

    private void waitKey(float sec)
    {
        light.color = Color.red;
        yield return new WaitForSeconds(.3f);
        light.color = Color.white;
    }
    private void waitKey(int sec)
    {
        Debug.Log("waitKey");
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
