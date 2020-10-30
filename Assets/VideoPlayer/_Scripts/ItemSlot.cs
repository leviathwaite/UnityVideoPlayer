using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Slot for draggable to be dropped in

// TODO fix multiple drops. Want new to replace old draggable.
// TODO Add Answer(number?) to be evaluated
public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private bool containsItem = false;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float dropDistance = 1;

    private RectTransform rectTransform;
    private RectTransform parentRectTransform;
    private Draggable currentDraggable;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null) // && containsItem == false)
        {
            containsItem = true;

            // draggable item needs anchor points applied
            Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if(draggable)
            {
                distance = Vector2.Distance(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition, rectTransform.anchoredPosition);
                if(distance < dropDistance)
                {
                    // TODO not working
                    // remove current and replace with new
                    if (currentDraggable != null)
                    {
                        currentDraggable.ResetToStartPosition();
                    }

                    draggable.SetInSlot(rectTransform.anchoredPosition);

                    currentDraggable = draggable;
                }
            }
                
        }
    }
}
