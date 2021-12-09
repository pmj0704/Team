using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField]
    private GameObject onOffText;

    private bool textOnOff = false; 
    private bool tvOnOff = false;

    private void Update()
    {
        if (!GameManager.Instance.TVoff)
        {
            tvOnOff = true;
            transform.GetChild(0).gameObject.SetActive(tvOnOff);
        }
        else
        {
            tvOnOff = false;
            transform.GetChild(0).gameObject.SetActive(tvOnOff);
        }

        if(GameManager.Instance.repeatTime == 26 && !GameManager.Instance.TVoff)
        {
            onOffText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            textOnOff = true;
            onOffText.SetActive(textOnOff);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            textOnOff = false;
            onOffText.SetActive(textOnOff);
        }
    }
    

}
