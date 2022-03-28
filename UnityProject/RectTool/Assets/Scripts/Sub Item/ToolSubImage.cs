using UnityEngine;

public class ToolSubImage : ToolImage
{
    [SerializeField] private RectTransform m_RectTransform;

    [Header("Anchor Position")]
    [SerializeField] private RectTransform tl;
    [SerializeField] private RectTransform tr;
    [SerializeField] private RectTransform bl;
    [SerializeField] private RectTransform br;

    private AnchorPoint tlPoint;
    private AnchorPoint trPoint;
    private AnchorPoint blPoint;
    private AnchorPoint brPoint;
    private CenterPoint cPoint;

    private bool _isFocus;
    public bool isFocus => _isFocus;

    private void Awake()
    {
        _isFocus = false;
    }

    public void RegisterPoint(AnchorPoint tlPoint, AnchorPoint trPoint, AnchorPoint blPoint, AnchorPoint brPoint, CenterPoint cPoint)
    {
        this.tlPoint = tlPoint;
        this.trPoint = trPoint;
        this.blPoint = blPoint;
        this.brPoint = brPoint;
        this.cPoint = cPoint;
        _isFocus = true;
    }

    public void SetupRectPoint(Vector2 point, AnchorPointType type)
    {
        Vector2 parentSize = RectToolManager.Instance.GetScreenSize();
        Vector2 newRect = new Vector2(point.x / parentSize.x, point.y / parentSize.y);

        var currentAnchorMin = m_RectTransform.anchorMin;
        var currentAnchorMax = m_RectTransform.anchorMax;

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

    public void SetupCenterPoint(Vector2 point)
    {
        transform.position = point;
        ACConverter.AnchorToCorners(m_RectTransform,RectToolManager.Instance.GetMainRectTransform());
        UpdateOtherRect();
    }

    public void UpdateOtherRect(AnchorPointType type = AnchorPointType.Center)
    {
        if (!type.Equals(AnchorPointType.TopLeft))
            tlPoint.SetPosition(tl.position);
        if (!type.Equals(AnchorPointType.TopRight))
            trPoint.SetPosition(tr.position);
        if (!type.Equals(AnchorPointType.BottomLeft))
            blPoint.SetPosition(bl.position);
        if (!type.Equals(AnchorPointType.BottomRight))
            brPoint.SetPosition(br.position);
        if (!type.Equals(AnchorPointType.Center))
            cPoint.SetPosition(transform.position);
    }

    public override void Reset()
    {
        base.Reset();
        tlPoint = null;
        trPoint = null;
        blPoint = null;
        brPoint = null;
        cPoint = null;
        _isFocus = false;
    }
}