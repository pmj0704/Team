using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggy : MonoBehaviour
{
    private GameObject EyeBallL;
    private GameObject EyeBallR;
    private void Start()
    {
        EyeBallL = transform.GetChild(0).gameObject;
        EyeBallR = transform.GetChild(1).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EyeBallL.SetActive(true);
            EyeBallR.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EyeBallL.SetActive(false);
            EyeBallR.SetActive(false);
        }
    }
}
