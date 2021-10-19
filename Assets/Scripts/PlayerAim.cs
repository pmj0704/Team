using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private bool Move = false;
    Collider collider;
    private void OnTriggerStay(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Drawer":
                if(Input.GetKeyDown(KeyCode.F))
                {
                    collider = other;
                    Move = true;
                }
                break;
        }
    }
    private void Update()
    {
        if(Move)
        {
            if (collider.transform.position.x < 0.1f) collider.transform.position = Vector3.MoveTowards(collider.transform.position, new Vector3(0.5f, collider.transform.position.y, collider.transform.position.z), Time.deltaTime * 2);
            else collider.transform.position = Vector3.MoveTowards(collider.transform.position, new Vector3(0.05f, collider.transform.position.y, collider.transform.position.z), Time.deltaTime * 2);

            if (collider.transform.position.x < 0.051 || collider.transform.position.x > 0.49) Move = false;
        }
    }
}
