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
                    if (playerAim.collider.GetComponent<Drawer>().isClosed)
                    {
                        playerAim.collider.transform.position = new Vector3(playerAim.collider.transform.position.x, playerAim.collider.transform.position.y, playerAim.collider.transform.position.z - 3);
                        StartCoroutine(flip());
                    }
                    else
                    {
                        playerAim.collider.transform.position = new Vector3(playerAim.collider.transform.position.x, playerAim.collider.transform.position.y, playerAim.collider.transform.position.z + 3);
                        StartCoroutine(flip());

                    }
                }
            }
            else if(playerAim.collider.tag == "Drawer1")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (playerAim.collider.GetComponent<Drawer>().isClosed)
                    {
                        playerAim.collider.transform.position = new Vector3(playerAim.collider.transform.position.x + 3, playerAim.collider.transform.position.y, playerAim.collider.transform.position.z);
                        StartCoroutine(flip());
                    }
                    else
                    {
                        if (!(playerAim.collider.GetComponent<Drawer>().includeKey))
                        {
                            playerAim.collider.transform.position = new Vector3(playerAim.collider.transform.position.x - 3, playerAim.collider.transform.position.y, playerAim.collider.transform.position.z);
                            StartCoroutine(flip());
                        }
                    }
                }
            }
            if (playerAim.collider.tag == "Untagged")
            {
                Debug.Log("��ü����");
            }
        }
    }
    private IEnumerator flip()
    {
        yield return new WaitForSeconds(.1f);
        playerAim.collider.GetComponent<Drawer>().isClosed = !playerAim.collider.GetComponent<Drawer>().isClosed;
    }

}
