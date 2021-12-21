using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject Light;
    [SerializeField]
    private VideoPlayer videoPlayer;
    private bool esc = false;
    private bool start = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            Light.SetActive(true);
            StartCoroutine(Playvideo());
            start = true;
        }
    }
    private IEnumerator Playvideo()
    {
        yield return new WaitForSeconds(5f);
        videoPlayer.Play();
    }
    private void Update()
    {
        if(GameManager.Instance.esc && esc && start)
        {
            videoPlayer.Pause();
            esc = false;
        }
        else if(!GameManager.Instance.esc && !esc && start)
        {
            videoPlayer.Play();
            esc = true;
        }
    }
}
