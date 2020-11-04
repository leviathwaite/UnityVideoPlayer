﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

// Controls for video player component
// TODO Stop should show first frame or blank screen/logo
// TODO On start should  show blank screen or logo. If has video should show first frame
// TODO build Media Controller to schedule video and tests timing. 
// TODO user schedular to place videos and test(in between and during videos)
public class VideoController : MonoBehaviour
{
    // Controls
    // play, pause, stop, seek, loop, restart, back 10, change speed, next video, prev video
    // Hide, SetSize

    public VideoClip[] videos;

    [SerializeField]
    private int currentVideo = 0;

    private VideoPlayer _videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    public void Play()
    {
        _videoPlayer.clip = videos[currentVideo];
        _videoPlayer.Play();
    }

    public void Stop()
    {
        _videoPlayer.frame = 1;
        _videoPlayer.Stop();
    }

    public void Pause()
    {
        _videoPlayer.Pause();
    }

    public void StepForward()
    {
        _videoPlayer.StepForward();
    }

    public void Loop()
    {
        _videoPlayer.isLooping = !_videoPlayer.isLooping;
    }

    public void NextVideo()
    {
        currentVideo++;
        currentVideo = Mathf.Clamp(currentVideo, 0, videos.Length - 1);
        _videoPlayer.clip = videos[currentVideo];
        _videoPlayer.Play();

        if(currentVideo == videos.Length - 1)
        {
            // TODO What to do if no more videos? Show message?
            Debug.Log("Last video");
        }
        
    }

   
}
