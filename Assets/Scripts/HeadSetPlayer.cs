using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetPlayer : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip headSetMusic;

    private void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        SoundPlay(headSetMusic, musicPlayer);
    }

    private void Update()
    {
        if(GameManager.Instance.hasSpeaker % 2 == 0)
        {
            musicPlayer.volume = .5f;
        }
        else
        {
            musicPlayer.volume = 0f;
        }
    }


    public void SoundPlay(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.time = 0;
        audioSource.Play();
    }

}
