using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorPoint : Point, IDragHandler
{  
    [SerializeField] private AnchorPointType m_AnchorPointType;

    public Action<Vector2, AnchorPointType> OnAnchorDrag;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        GenerateRectPoint();
    }

    public void SetPosition(Vector2 newPosition)
    {
        transform.position = new Vector3(newPosition.x, newPosition.y, startPosition.z);
    }

    private void GenerateRectPoint()
    {
        Vector2 parentSize = RectToolManager.Instance.GetScreenSize();
        Vector2 ourMinCorner = m_RectTransform.anchorMin.ComponentMultiply(parentSize) + m_RectTransform.offsetMin;
        Vector2 ourMaxCorner = m_RectTransform.anchorMax.ComponentMultiply(parentSize) + m_RectTransform.offsetMax;
        Vector2 centerPoint = Vector2.Lerp(ourMinCorner, ourMaxCorner, 0.5f);

        OnAnchorDrag?.Invoke(centerPoint, m_AnchorPointType);
    }
}

public enum AnchorPointType { Center, TopLeft, TopRight, BottomLeft, BottomRight }