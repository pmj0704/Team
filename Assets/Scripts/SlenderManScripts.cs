using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderManScripts : MonoBehaviour
{
    private Transform players;
    private Vector3 targetPosition;

    //private float speed = 5f; 플레이어에게 다가가게 하고 싶은 경우의 속도

    void Start()
    {
        players = GameObject.FindGameObjectWithTag("Player").transform;
        // 다가갈 대상의 태그를 찾는다
    }
    void Update()
    {
        targetPosition = new Vector3(players.position.x, transform.position.y, players.position.z);
        // vector3 형태의 targetposition의 위치를 플레이어(태그로 얻어옴)의 태그로 얻어옴 
        // (플레이어의 포지션은 y축만 움직인다.) >> x축과 z축이 0으로 고정됨
        transform.LookAt(targetPosition);
        // targetposition의 포지션 값으로 lookat함수


        /* transform.position += transform.forward * speed * Time.deltaTime;
         플레이어에게 다가가게 하고 싶은 경우 */
    }
}
