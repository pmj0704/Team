using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("gj");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
    }
}
