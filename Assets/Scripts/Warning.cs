using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetMouseButton(0)|| Input.GetMouseButton(1))
        {
            gameObject.SetActive(false);
        }
    }
}
