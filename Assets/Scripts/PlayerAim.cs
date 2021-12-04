using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    RaycastHit playerAim;
    float maxDistance = 15f;
    public LayerMask layerMask;

    [SerializeField]
    private GetKey key;

    private int tvOnOff = 0;
    private bool tvSeting = false;


    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // 마우스커서 안 보이는 것, esc하면 풀림
    }
    // 기본적으로 플레이어 에임에서 레이캐스트가 나가게 해둠
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out playerAim, maxDistance, layerMask))
        // 레이캐스트는 물체 감지시 true 반환
        {
            if (playerAim.collider.tag == "Drawer")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    playerAim.collider.GetComponent<Drawer>().OpenAndCloseF(1);
                }
            }
            else if(playerAim.collider.tag == "Drawer1")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    playerAim.collider.GetComponent<Drawer>().OpenAndCloseF(2);
                }
            }
            if (playerAim.collider.tag == "Speaker")
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.Instance.hasSpeaker = !GameManager.Instance.hasSpeaker;
                    if ((GameManager.Instance.repeatTime == 4 || GameManager.Instance.repeatTime == 18) && !GameManager.Instance.hasKey) key.gameObject.SetActive(true);
                }
            }
            if (playerAim.collider.tag == "Tv")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.Instance.WelcomeF();
                    if (GameManager.Instance.repeatTime == 12 && !GameManager.Instance.hasKey) key.gameObject.SetActive(true);
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
            }
            if (playerAim.collider.tag == "Untagged")
            {
            }
        }
    }
    private IEnumerator Endding()
    {
        yield return new WaitForSeconds(9f);
        GameManager.Instance.End();
    }
}
