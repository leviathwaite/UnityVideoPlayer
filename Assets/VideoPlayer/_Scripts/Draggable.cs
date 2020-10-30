using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Draggable UI element
// Returns to intial position when not placed in a slot

// TODO add answer so can be evaluatedd
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private float draggedAlpha = 0.6f;
    [SerializeField]
    private bool inSlot = false;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startingPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // startingPosition = rectTransform.localPosition / canvas.scaleFactor;
        startingPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = draggedAlpha;
        canvasGroup.blocksRaycasts = false;

        inSlot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        if(inSlot == false)
        {
            // return to starting position
            // rectTransform.localPosition = startingPosition;
            ResetToStartPosition();
        }
    }

    public void SetInSlot(Vector3 position)
    {
        inSlot = true;
        rectTransform.anchoredPosition = position;
    }

    public void ResetToStartPosition()
    {
        inSlot = false;
        rectTransform.anchoredPosition = startingPosition;
    }
}
