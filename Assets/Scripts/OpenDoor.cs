using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject trueText;
    [SerializeField]
    private GameObject falseText;
    private bool Door = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Door)
        {
            GameManager.Instance.hasKey = false;
            trueText.SetActive(false);
            GameManager.Instance.NextStage();
            GameManager.Instance.jsonSave.Save();
            Door = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            if (GameManager.Instance.hasKey)
            {
                trueText.SetActive(true);
                Door = true;
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
