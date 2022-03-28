using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Point : MonoBehaviour, IDragHandler
{
    [SerializeField] protected RectTransform m_RectTransform;

    public Action OnPointDrag;

    protected Vector3 startPosition;

    protected virtual void Awake()
    {
        startPosition = transform.position;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, eventData.position.y, startPosition.z);
        OnPointDrag?.Invoke();
    }
}