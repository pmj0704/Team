using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAim : MonoBehaviour
{
    RaycastHit playerAim;
    float maxDistance = 15f;
    public LayerMask layerMask;

    [SerializeField]
    private GetKey key;

    [SerializeField]
    public Image testImage;

    private int tvOnOff = 0;
    private bool tvSeting = false;

    private bool TV = false;
    private bool Drawer = false;
    private bool Speaker = false;
    private bool Brakeable = false;

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // ���콺Ŀ�� �� ���̴� ��, esc�ϸ� Ǯ��
    }
    // �⺻������ �÷��̾� ���ӿ��� ����ĳ��Ʈ�� ������ �ص�

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (TV)
            {
                Debug.Log("F");
                GameManager.Instance.WelcomeF();
                if (GameManager.Instance.repeatTime == 12 && !GameManager.Instance.hasKey)
                {
                    key.gameObject.SetActive(true);
                    StartCoroutine(KeyFall()); 
                }
                if (GameManager.Instance.repeatTime == 13) GameManager.Instance.light.color = Color.white;
                if (GameManager.Instance.repeatTime == 26)
                {
                    StartCoroutine(Endding());
                    GameManager.Instance.TVoff = false;
                }
                else
                {
                    GameManager.Instance.TVoff = !GameManager.Instance.TVoff;
                }
            }
            if(Drawer)
            {
                playerAim.collider.GetComponent<Drawer>().OpenAndCloseF(1);
            }
            if(Speaker)
            {
                GameManager.Instance.hasSpeaker = !GameManager.Instance.hasSpeaker;
                if ((GameManager.Instance.repeatTime == 4 || GameManager.Instance.repeatTime == 18) && !GameManager.Instance.hasKey)
                {
                    key.gameObject.SetActive(true);
                    StartCoroutine(KeyFall());
                }
            }
            if(Brakeable)
            {
                playerAim.collider.transform.parent.GetComponent<BreakableWall>().BreakWall();
                playerAim.collider.transform.GetComponent<AudioSource>().Play();
            }

            Drawer = false;
            Speaker = false;
            TV = false;
            Brakeable = false;
        }
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out playerAim, maxDistance, layerMask))
        // ����ĳ��Ʈ�� ��ü ������ true ��ȯ
        {
            if (playerAim.collider.tag == "Drawer")
            {
                Drawer = true;
            }
            else
            {
                Drawer = false;
            }

            if (playerAim.collider.tag == "Speaker")
            {
                Speaker = true;
            }
            else
            {
                Speaker = false;
            }

            if (playerAim.collider.tag == "Tv")
            {
                TV = true;
            }
            else
            {
                TV = false;
            }
            if (playerAim.collider.tag == "BreakableWall")
            {
                Brakeable = true;
            }
            else
            {
                Brakeable = false;
            }
            if (playerAim.collider.tag == "SlenderMan")
            {
                GameManager.Instance.slenderManSound = true;
            }
            if (playerAim.collider.tag == "AnimationTest")
            {
                if (Input.GetKeyDown(KeyCode.F))
                testImage.gameObject.SetActive(true);
            }
            if (playerAim.collider.tag == "Untagged")
            {

            }
        }
        else
        {
            Drawer = false;
            Speaker = false;
            TV = false;
            Brakeable = false;
        }
    }
    private IEnumerator Endding()
    {
        yield return new WaitForSeconds(9f);
        GameManager.Instance.End();
    }
    private IEnumerator KeyFall()
    {
        yield return new WaitForSeconds(1.2f);
        key.keyfall.Play();
    }
}
