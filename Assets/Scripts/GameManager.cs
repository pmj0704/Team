using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoSingleton<GameManager>
{
    [HideInInspector]
    public bool hasKey = false;
    [HideInInspector]
    public bool hasSpeaker = false;
    [HideInInspector]
    public bool TVoff = true;
    [SerializeField]
    private VideoPlayer TV;
    [SerializeField]
    private VideoClip TestSbj;
    [SerializeField]
    private VideoClip zzz;
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
    [SerializeField]
    private GameObject Esc;
    public bool uiOn = false;
    public JsonSave jsonSave;
    public bool Started = false;
    [SerializeField]
    private GameObject TvSound;
    [SerializeField]
    private GameObject SmileObj;
    [SerializeField]
    private AudioSource audioSource;
    private bool respawning = true;
    [SerializeField]
    private AudioSource voice;
    private bool cry = true;
    private float pitchF = 0;
    [SerializeField]
    private AudioSource monster;
    private bool room22 = true;
    private Animator monsterA;
    private bool room23 = true;
    [SerializeField]
    private GameObject mainMenu;
    private void Start()
    {
        Time.timeScale = 0;
        hasSpeaker = false;
        TVoff = true;  
    }
    public void StartGame()
    {
        if (repeatTime == 9) Respawn.position = roomPos[1];
        if (repeatTime == 15) Respawn.position = roomPos[2];
        playerTransform.position = Respawn.position;
        if (repeatTime != 11) smileMats[3].mainTexture = smileMats[4].mainTexture;
        if (repeatTime != 7) smileMats[2].mainTexture = smileMats[1].mainTexture;
        if (repeatTime != 11) smileMats[3].mainTexture = smileMats[4].mainTexture;
        if (repeatTime != 7) smileMats[2].mainTexture = smileMats[1].mainTexture;
        Key.KeyPos(repeatTime);
        checkWait();
        IFText.text = inform[repeatTime];
        monsterA = monster.GetComponent<Animator>();

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !uiOn)
        {
            respawning = true;
            Esc.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            hasSpeaker = false;
            TVoff = true;
            uiOn = true;
            monster.enabled = false;
            voice.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && uiOn)
        {
            respawning = true;
            Esc.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
            hasSpeaker = true;
            uiOn = false;
            Resume();
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
        respawning = true;
        movePlayer();
        fadeCamera();
        inventoryKey();
        timerReset = true;
        IFText.text = inform[repeatTime];
        IFText.gameObject.SetActive(false);
        Key.KeyPos(repeatTime);
        textOff = true;
        Key.inDraweBool();
        hasSpeaker = true;
        checkEvent();
    }
    private void checkEvent()
    {
        if(repeatTime == 4 || repeatTime == 12 || repeatTime == 18)
        {
            Key.gameObject.SetActive(false);
        }
    }
    private void checkWait()
    {
        switch (repeatTime)
        {
            case 0:
                smileMats[10].mainTexture = smileMats[11].mainTexture;
                light.color = Color.white;
                light.range = 121;
                smileMats[2].mainTexture = smileMats[1].mainTexture;
                smileMats[10].color = smileMats[11].color;
                Welcome.text = "welcome";
                Respawn.position = roomPos[0];
                audioSource.pitch = 1;
                smileMats[3].mainTexture = smileMats[4].mainTexture;
                TV.isLooping = true;
                TV.clip = zzz;
                break;

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
                Respawn.position = roomPos[0];
                RespawnF();
                waitKey(15);
                smileMats[2].mainTexture = smileMats[1].mainTexture;
                break;
            case 9:
                waitKey(15);
                break;
            case 10:
                waitKey(15);
                Respawn.position = roomPos[1];
                RespawnF();
                break;
            case 11:
                Respawn.position = roomPos[0];
                RespawnF();
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
                Respawn.position = roomPos[0];
                RespawnF();
                break;
            case 16:
                Respawn.position = roomPos[2];
                RespawnF();
                TvSound.SetActive(true);
                StartCoroutine(room2());
                break;
            case 17:
                Respawn.position = roomPos[0];
                RespawnF();
                TvSound.SetActive(false);
                SmileObj.SetActive(true);
                waitKey(15);

                break;
            case 18:
                Respawn.position = roomPos[0];
                RespawnF();
                SmileObj.SetActive(false);
                waitKey(15);
                audioSource.pitch = -3;
                thirteen = true;
                break;
            case 19:
                audioSource.pitch = 1;
                StartCoroutine(room2());
                Respawn.position = roomPos[2];
                RespawnF();
                TvSound.SetActive(true);
                break;
            case 20:
                TvSound.SetActive(false);

                Respawn.position = roomPos[0];
                RespawnF();
                light.range = 50;
                if (cry)
                {
                    voice.enabled = true;
                    cry = false;
                }
                break;
            case 21:
                smileMats[2].mainTexture = smileMats[5].mainTexture;

                if (!cry)
                {
                    StartCoroutine(Crying());
                }
                break;
            case 22:
                voice.enabled = false;
                if (room22)
                {
                    smileMats[2].mainTexture = smileMats[5].mainTexture;
                    smileMats[6].mainTexture = smileMats[9].mainTexture;
                    monster.gameObject.SetActive(true);
                    Welcome.text = "139";
                    hasSpeaker = false;
                    StartCoroutine(Room22());
                }
                break;
            case 23:
                waitKey(15);

                if (room23)
                {
                    smileMats[2].mainTexture = smileMats[5].mainTexture;
                    smileMats[6].mainTexture = smileMats[7].mainTexture;
                    monster.gameObject.SetActive(true);
                    hasSpeaker = false;
                    Welcome.text = "You";
                    monster.enabled = true;
                    monsterA.Play("Scream");
                    light.range = 87;
                    light.color = Color.gray;
                    room22 = true;
                    room23 = false;
                }
                break;
            case 24:
                waitKey(15);

                if (room22)
                {
                    smileMats[2].mainTexture = smileMats[5].mainTexture;
                    monster.enabled = false;
                    monster.gameObject.SetActive(true);
                    monster.gameObject.transform.localPosition = new Vector3(20.21486f, 0.1818733f, 25.2f);
                    monster.gameObject.transform.rotation = Quaternion.Euler(0, -0.01568631f, 0);
                    monsterA.Play("Idle");
                    smileMats[6].mainTexture = smileMats[8].mainTexture;
                    hasSpeaker = false;
                    light.range = 87;
                    light.color = Color.gray;
                    Welcome.text = "";
                    room22 = false;
                    room23 = true;
                }
                break;
            case 25:
                waitKey(15);

                if (room23)
                {
                    light.range = 0;
                    StartCoroutine(Room25());
                smileMats[2].mainTexture = smileMats[1].mainTexture;
                monster.gameObject.SetActive(false);
                light.range = 121;
                light.color = Color.white;
                Welcome.text = "dd j\ng";
                hasSpeaker = false;
                smileMats[10].mainTexture = smileMats[0].mainTexture;
                    smileMats[10].color = Color.white;
                TVoff = false;
                    room23 = false;
                    room22 = true;
                }
                break;
            case 26:
                Key.gameObject.SetActive(false);
                waitKey(15);
                hasSpeaker = false;
                if (room22)
                {
                    Welcome.text = "End Game";
                    TV.clip = TestSbj;
                    TVoff = true;
                    room22 = false;
                    TV.isLooping = false;
                }
                break;
            default:
                break;
        }
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
        hasSpeaker = true;
        checkEvent();
    }
    private IEnumerator RedLight()
    {
        if (!thirteen)
        {
            thirteen = true;
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

    private void waitKey(int sec)
    {
        if (second > sec && textOff && !hasKey)
        {
            IFText.gameObject.SetActive(true);
            textOff = false;
        }
        else if(!(second > sec) || hasKey)
        {
            IFText.gameObject.SetActive(false);
        }
    }
    public void Stop()
    {
        hasSpeaker = false;
        TVoff = true;
        voice.enabled = false;
    }
    public void Resume()
    {
        hasSpeaker = false;
        if(repeatTime == 20 || repeatTime == 21)voice.enabled = true;
        if (repeatTime == 23) monster.enabled = true;
    }
    public void WelcomeF()
    {
        Welcome.text = "welcome";
    }
    public void RespawnF()
    {
        if(respawning) playerTransform.position = Respawn.position;
        respawning = false;
    }
    public void RespawnTrue()
    {
        respawning = true;
    }
    private IEnumerator Crying()
    {
        cry = false;
        yield return new WaitForSeconds(2f);
        hasSpeaker = false;

        while (repeatTime == 21)
        {
            pitchF = Random.Range(-1f, 3);
            voice.pitch = pitchF;
            yield return new WaitForSeconds(.2f);
        }
    }
    private IEnumerator Room22()
    {
        
        room22 = false;
        light.range = 15;
        yield return new WaitForSeconds(3f);
        light.range = 87;
        light.color = Color.gray;
    }
    private IEnumerator Room25()
    {
        yield return new WaitForSeconds(2f);
        light.range = 121;
    }
    public void End()
    {
        mainMenu.SetActive(true);
        respawning = true;
        Cursor.visible = true;
        Time.timeScale = 0;
        hasSpeaker = false;
        TVoff = true;
        uiOn = true;
        monster.enabled = false;
        voice.enabled = false;
        repeatTime = 0;
        jsonSave.Save();
    }
}
