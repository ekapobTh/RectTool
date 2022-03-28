using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorPoint : MonoBehaviour, IDragHandler
{  
    [SerializeField] private RectTransform m_RectTransform;
    [SerializeField] private AnchorPointType m_AnchorPointType;

    public Action<Vector2, AnchorPointType> OnDragAction;

    private Vector3 startPosition;
    private Camera m_Camera;

    private void Awake()
    {
        startPosition = transform.position;
        m_Camera = Camera.main;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, eventData.position.y, startPosition.z);
        GenerateRectPoint();
    }

    public void SetPosition(Vector2 newPosition)
    {
        transform.position = new Vector3(newPosition.x, newPosition.y, startPosition.z);
    }

    [ContextMenu("Show Point")]
    public void GenerateRectPoint()
    {
        Vector2 parentSize = RectToolManager.Instance.GetScreenSize();
        Vector2 ourMinCorner = m_RectTransform.anchorMin.ComponentMultiply(parentSize) + m_RectTransform.offsetMin;
        Vector2 ourMaxCorner = m_RectTransform.anchorMax.ComponentMultiply(parentSize) + m_RectTransform.offsetMax;
        Vector2 centerPoint = Vector2.Lerp(ourMinCorner, ourMaxCorner, 0.5f);

        OnDragAction?.Invoke(centerPoint, m_AnchorPointType);

        //Debug.Log($"{parentSize} : {centerPoint}");
    }
}

public enum AnchorPointType { TopLeft, TopRight, BottomLeft, BottomRight }