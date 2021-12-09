using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject onOffText;
    [SerializeField]
    private GameObject light;

    private bool headSetOnOff = false;

    private AudioSource musicPlayer;
    public AudioClip headSetMusic;
    private bool start = true;
    private void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (GameManager.Instance.hasSpeaker)
        {
            musicPlayer.volume = .5f;
            if (start)
            {
                SoundPlay(headSetMusic, musicPlayer);
                start = false;
            }
        }
        else
        {
            if (!start)
            {
                SoundStop(headSetMusic, musicPlayer);
                start = true;
            }
            musicPlayer.volume = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            headSetOnOff = true;
            onOffText.SetActive(headSetOnOff);
            light.SetActive(headSetOnOff);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerAim")
        {
            headSetOnOff = false;
            onOffText.SetActive(headSetOnOff);
            light.SetActive(headSetOnOff);
        }
    }

    public void SoundPlay(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void SoundStop(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.loop = true;
    }
}
    
