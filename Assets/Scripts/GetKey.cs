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
    private bool Key = false;
    public AudioSource keyfall;
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
                    Key = true;
                }
            }
            else
            {
                inventoryText = true;
                getKeyText.SetActive(inventoryText);
                light.SetActive(inventoryText);
                Key = true;
            }
        }
        if(other.tag == "Drawer" || other.tag == "Drawer1")
        {
            inDrawer = true;
            drawer = other.GetComponent<Drawer>();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Key)
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
            Key = false;
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
        Key = false;
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




