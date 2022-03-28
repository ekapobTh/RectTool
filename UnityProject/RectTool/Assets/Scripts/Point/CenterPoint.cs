using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CenterPoint : Point, IDragHandler
{
    public Action<Vector2> OnCenterDrag;

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
        OnCenterDrag?.Invoke(transform.position);
    }
}