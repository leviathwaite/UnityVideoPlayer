using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

// Draggable UI element
// Returns to intial position when not placed in a slot

// TODO add answer so can be evaluatedd
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UILineRenderer lineRenderer;

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private float draggedAlpha = 0.6f;
    [SerializeField]
    private bool inSlot = false;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startingPosition;

    // for line renderer
    private List<Vector2> linePoints;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // startingPosition = rectTransform.localPosition / canvas.scaleFactor;
        startingPosition = rectTransform.anchoredPosition;

        lineRenderer.LineThickness = 10;
        linePoints = new List<Vector2>();
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
            ClearLineRenderer();
            ResetToStartPosition();
        }
    }

    public void SetInSlot(Vector3 position)
    {
        inSlot = true;
        rectTransform.anchoredPosition = position;

        ClearLineRenderer();
        DrawLineRenderer();
    }

    public void ResetToStartPosition()
    {
        inSlot = false;
        rectTransform.anchoredPosition = startingPosition;

        ClearLineRenderer();
    }

    public bool InSlot()
    {
        return inSlot;
    }

    private void DrawLineRenderer()
    {
        // Draw line
        lineRenderer.gameObject.SetActive(true);
        linePoints.Add(startingPosition);
        linePoints.Add(rectTransform.anchoredPosition);
        lineRenderer.Points = linePoints.ToArray();
    }

    private void ClearLineRenderer()
    {
        // TODO is there a better way to clear points?
        linePoints.Clear();
        lineRenderer.Points = linePoints.ToArray();
        lineRenderer.gameObject.SetActive(false);
    }
}
