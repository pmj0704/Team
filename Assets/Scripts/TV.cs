using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            videoPlayer.loopPointReached += EndReached;
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}
