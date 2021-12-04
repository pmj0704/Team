using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKey : MonoBehaviour
{
    [SerializeField]
    private GameObject getKeyText;
    [SerializeField]
    private Vector3[] stageKey;
    [SerializeField]
    private GameObject light;
    private bool inventorykey = false;
    private bool inventoryText = false;
    private bool inDrawer = false;

    Drawer drawer;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            if (inDrawer)
            {
                if (!(drawer.isClosed))
                {
                    inventoryText = true;
                    getKeyText.SetActive(inventoryText);
                    light.SetActive(inventoryText);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
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
            else
            {
                inventoryText = true;
                getKeyText.SetActive(inventoryText);
                light.SetActive(inventoryText);
                if (Input.GetKeyDown(KeyCode.F))
                {
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
        if(other.tag == "Drawer" || other.tag == "Drawer1")
        {
            inDrawer = true;
            drawer = other.GetComponent<Drawer>();
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
    public void KeyPos(int stage)
    {
        light.SetActive(inventoryText);
        gameObject.SetActive(true);
        gameObject.transform.position = stageKey[stage];
    }
    public void inDraweBool()
    {
        inDrawer = false;
    }
}




