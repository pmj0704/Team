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
    private void OnCollisionStay(Collision other)
    {
        
        if(other.gameObject.tag == "Key")
        {
            Debug.Log("PlayerIn");

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GetKey");
            }
        }
    }
}
