using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "PlayerAim")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GetKey");
            }
        }
    }
}
