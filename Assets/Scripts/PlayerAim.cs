using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    RaycastHit playerAim;
    float maxDistance = 9.3f;
    public LayerMask layerMask;

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // 마우스커서 안 보이는 것, esc하면 풀림
    }
    // 기본적으로 플레이어 에임에서 레이캐스트가 나가게 해둠
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out playerAim, maxDistance, layerMask))
        {
            //Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red, 0.3f);
            // 레이캐스트 보는거 

            if (playerAim.collider.tag == "Drawer")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("서랍장오픈");
                }
            }
            if (playerAim.collider.tag == "Untagged")
            {
                Debug.Log("물체감지");
            }
        }
    }
}
