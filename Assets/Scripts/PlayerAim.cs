using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private bool Move = false;
    Collider collider;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        switch(other.gameObject.tag)
        {
            case "Drawer":
                if(Input.GetKeyDown(KeyCode.F))
                {

                }
                break;
        }
    }
    private void Open()
    {
        while()
    }
}
