using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderManScripts : MonoBehaviour
{
    private Transform players;
    private Vector3 targetPosition;

    //private float speed = 5f; �÷��̾�� �ٰ����� �ϰ� ���� ����� �ӵ�

    void Start()
    {
        players = GameObject.FindGameObjectWithTag("Player").transform;
        // �ٰ��� ����� �±׸� ã�´�
    }
    void Update()
    {
        targetPosition = new Vector3(players.position.x, transform.position.y, players.position.z);
        // vector3 ������ targetposition�� ��ġ�� �÷��̾�(�±׷� ����)�� �±׷� ���� 
        // (�÷��̾��� �������� y�ุ �����δ�.) >> x��� z���� 0���� ������
        transform.LookAt(targetPosition);
        // targetposition�� ������ ������ lookat�Լ�


        /* transform.position += transform.forward * speed * Time.deltaTime;
         �÷��̾�� �ٰ����� �ϰ� ���� ��� */
    }
}
