using System.Collections;
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
    [SerializeField]
    private int startingFrame = 1;

    private VideoPlayer videoPlayer;

   
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        // Play on awake needs to be enabled to allow scrubbing before pressing play
        videoPlayer.playOnAwake = true;
        videoPlayer.clip = videos[currentVideo];
        videoPlayer.frame = startingFrame;
        videoPlayer.Pause();
    }

    public void Play()
    {
        videoPlayer.clip = videos[currentVideo];
        videoPlayer.Play();
    }

    public void Stop()
    {
        // Using Pause() instead of Stop() to show first frame.
        videoPlayer.frame = startingFrame;
        videoPlayer.Pause();
    }

    public void Pause()
    {
        videoPlayer.Pause();
    }

    public void StepForward()
    {
        videoPlayer.StepForward();
    }

    public void Loop()
    {
        videoPlayer.isLooping = !videoPlayer.isLooping;
    }

    public void NextVideo()
    {
        currentVideo++;
        currentVideo = Mathf.Clamp(currentVideo, 0, videos.Length - 1);
        videoPlayer.clip = videos[currentVideo];
        videoPlayer.Play();
        videoPlayer.frame = startingFrame;
        videoPlayer.Pause();

        if(currentVideo == videos.Length - 1)
        {
            // TODO What to do if no more videos? Show message?
            Debug.Log("Last video");
        }
        
    }

   
}
