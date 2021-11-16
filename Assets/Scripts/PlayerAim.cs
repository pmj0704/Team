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
        // ���콺Ŀ�� �� ���̴� ��, esc�ϸ� Ǯ��
    }
    // �⺻������ �÷��̾� ���ӿ��� ����ĳ��Ʈ�� ������ �ص�
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out playerAim, maxDistance, layerMask))
        // ����ĳ��Ʈ�� ��ü ������ true ��ȯ
        {
            if (playerAim.collider.tag == "Drawer")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("���������");
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
                Debug.Log("��ü����");
            }
        }
    }

}
