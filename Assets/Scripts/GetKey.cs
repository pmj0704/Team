using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKey : MonoBehaviour
{
    [SerializeField]
    private GameObject getKeyText;

    [SerializeField]
    private GameObject light;
    private bool inventorykey = false;
    private bool inventoryText = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {

            inventoryText = true;
            getKeyText.SetActive(inventoryText);
            light.SetActive(inventoryText);

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GetKey");
                GameManager.Instance.hasKey = true;
                inventorykey = true;
                GameManager.Instance.inventoryKey();
                if (inventorykey == true)
                {
                    inventoryText = false;
                    getKeyText.SetActive(inventoryText);
                }
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            inventoryText = false;
            getKeyText.SetActive(inventoryText);
            light.SetActive(inventoryText);
        }

    }
}