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
                }
            }
            if (playerAim.collider.tag == "Untagged")
            {
                Debug.Log("��ü����");
            }
        }
    }


}
