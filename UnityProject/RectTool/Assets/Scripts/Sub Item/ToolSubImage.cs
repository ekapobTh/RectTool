using UnityEngine;

public class ToolSubImage : ToolImage
{
    [SerializeField] private RectTransform m_RectTransform;

    [Header("Anchor Position")]
    [SerializeField] private RectTransform tl;
    [SerializeField] private RectTransform tr;
    [SerializeField] private RectTransform bl;
    [SerializeField] private RectTransform br;

    // TODO Register AnchorPoint
    [Header("Anchor Point")]
    [SerializeField] private AnchorPoint tlAnchorPoint;
    [SerializeField] private AnchorPoint trAnchorPoint;
    [SerializeField] private AnchorPoint blAnchorPoint;
    [SerializeField] private AnchorPoint brAnchorPoint;

    private void Awake()
    {
        tlAnchorPoint.OnDragAction = SetupRectPoint;
        trAnchorPoint.OnDragAction = SetupRectPoint;
        blAnchorPoint.OnDragAction = SetupRectPoint;
        brAnchorPoint.OnDragAction = SetupRectPoint;
    }

    public void SetupRectPoint(Vector2 point, AnchorPointType type)
    {
        Vector2 parentSize = RectToolManager.Instance.GetScreenSize();
        Vector2 newRect = new Vector2(point.x / parentSize.x, point.y / parentSize.y);

        var currentAnchorMin = m_RectTransform.anchorMin;
        var currentAnchorMax = m_RectTransform.anchorMax;
        Debug.Log($"{type} {newRect.x} {newRect.y}");
        switch (type)
        {
            case AnchorPointType.TopLeft:
                {
                    m_RectTransform.anchorMin = new Vector2(newRect.x, currentAnchorMin.y);
                    m_RectTransform.anchorMax = new Vector2(currentAnchorMax.x, newRect.y);
                }
                break;
            case AnchorPointType.TopRight:
                {
                    m_RectTransform.anchorMax = newRect;
                }
                break;
            case AnchorPointType.BottomLeft:
                {
                    m_RectTransform.anchorMin = newRect;
                }
                break;
            case AnchorPointType.BottomRight:
                {
                    m_RectTransform.anchorMin = new Vector2(currentAnchorMin.x, newRect.y);
                    m_RectTransform.anchorMax = new Vector2(newRect.x, currentAnchorMax.y);
                }
                break;
        }

        UpdateOtherRect(type);
    }

    public void UpdateOtherRect(AnchorPointType type)
    {
        if (!type.Equals(AnchorPointType.TopLeft))
            tlAnchorPoint.SetPosition(tl.position);
        if (!type.Equals(AnchorPointType.TopRight))
            trAnchorPoint.SetPosition(tr.position);
        if (!type.Equals(AnchorPointType.BottomLeft))
            blAnchorPoint.SetPosition(bl.position);
        if (!type.Equals(AnchorPointType.BottomRight))
            brAnchorPoint.SetPosition(br.position);
    }

    [ContextMenu("Show Point")]
    public void GenerateRectPoint()
    {
        Debug.Log($"{m_RectTransform.anchoredPosition}");
    }
}