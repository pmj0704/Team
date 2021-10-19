using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKey : MonoBehaviour
{
    [SerializeField]
    private GameObject getKeyText;
    [SerializeField]
    private GameObject getkeyImage;

    private bool inventorykey = false;
    private bool inventoryText = false;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {

             inventoryText = true;
             getKeyText.SetActive(inventoryText);
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GetKey");
                GameManager.Instance.hasKey = true;
                inventorykey = true;
                getkeyImage.SetActive(inventorykey);
              
                if(inventorykey == true)
                {
                    inventoryText = false;
                    getKeyText.SetActive(inventoryText);
                }
            }
        }
    }
}




