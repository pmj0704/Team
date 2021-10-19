using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKey : MonoBehaviour
{
    [SerializeField]
    private Text getKeyText;
    [SerializeField]
    private Image getkeyImage;

    [SerializeField]
    private GameObject getKey;

    private bool getKeyCheck = false;


    private void OnBecameVisible()
    // ∫Ò√Á¡¸
    {
        getKeyText.gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    // æ»∫Ò√Á¡¸
    {
        getKeyText.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {   
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameManager.Instance.hasKey = true;
                getkeyImage.gameObject.SetActive(true);
                getKey.gameObject.SetActive(false);
            }
        }
    }
}




