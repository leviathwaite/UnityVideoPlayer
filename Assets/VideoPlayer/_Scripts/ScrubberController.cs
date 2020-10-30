using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Used to control video frame via slider
// TODO smooth out scrubbing, kinda glitchy
public class ScrubberController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public VideoPlayer _videoPlayer;

    private Image progress;

   

    // Start is called before the first frame update
    void Start()
    {
        progress = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have a video
        if (_videoPlayer.frameCount > 0)
        {
            // percent of video played
            progress.fillAmount = (float)_videoPlayer.frame / (float)_videoPlayer.frameCount;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
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
        var frame = _videoPlayer.frameCount * pct;
        _videoPlayer.frame = (long)frame;
    }
}
