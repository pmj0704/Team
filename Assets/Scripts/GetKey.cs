using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private bool isVisible = false;
    private void OnBecameVisible()
    {
        isVisible = true;
        Debug.Log("vis");
    }
    private void OnBecameInvisible()
    {
        isVisible = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GetKey");
            }
        }
    }
}
