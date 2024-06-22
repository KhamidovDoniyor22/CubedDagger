using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDragger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    public List<RectTransform> dropTargets = new List<RectTransform>();
    public string dropTargetTag = "DropTarget";

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(dropTargetTag);
        foreach (GameObject target in targets)
        {
            RectTransform targetRectTransform = target.GetComponent<RectTransform>();
            if (targetRectTransform != null)
            {
                dropTargets.Add(targetRectTransform);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        bool isPlaced = false;

        foreach (RectTransform dropTarget in dropTargets)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(dropTarget, Input.mousePosition, canvas.worldCamera))
            {
                gameObject.transform.position = dropTarget.transform.position;
                isPlaced = true;
                break;
            }
        }

        if (!isPlaced)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}


