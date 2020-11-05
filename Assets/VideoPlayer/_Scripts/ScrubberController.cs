using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Used to control video frame via slider
// TODO smooth out scrubbing, kinda glitchy
// Maybe pause while scrubber is being used
public class ScrubberController : MonoBehaviour,  IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public VideoPlayer videoPlayer;

    private Image progress;

    void Start()
    {
        progress = GetComponent<Image>();
        progress.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have a video
        if (videoPlayer.frameCount > 0)
        {
            // percent of video played
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        videoPlayer.Pause();
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;
        // normalize point between 0-1
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var frame = videoPlayer.frameCount * pct;
        videoPlayer.frame = (long)frame;
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        videoPlayer.Play();
    }
}
