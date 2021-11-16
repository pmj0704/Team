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
                    Debug.Log("서랍장오픈");
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
            if (playerAim.collider.tag == "Untagged")
            {
                Debug.Log("물체감지");
            }
        }
    }

}
