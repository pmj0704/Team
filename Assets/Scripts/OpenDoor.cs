using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject trueText;
    [SerializeField]
    private GameObject falseText;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            if (GameManager.Instance.hasKey)
            {
                trueText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.Instance.hasKey = false;
                    trueText.SetActive(false);
                    GameManager.Instance.NextStage();
                    GameManager.Instance.jsonSave.Save();
                }
            }
            else
            {
                falseText.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            trueText.SetActive(false);
            falseText.SetActive(false);
        }
    }
}
