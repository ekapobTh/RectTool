using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectToolManager : MonoBehaviour
{
    private static RectToolManager _instance;
    public static RectToolManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<RectToolManager>();

            return _instance;
        }
    }

    [SerializeField] private Image backgroundImage;
    [SerializeField] private RectTransform backgroundRectTransform;

    [Header("Deafult Setting")]
    [SerializeField] private Sprite _defaultWrongSprite;
    public Sprite defaultWrongSprite => _defaultWrongSprite;

    [Header("Point")]
    [SerializeField] private AnchorPoint tlPoint;
    [SerializeField] private AnchorPoint trPoint;
    [SerializeField] private AnchorPoint blPoint;
    [SerializeField] private AnchorPoint brPoint;
    [SerializeField] private CenterPoint cPoint;

    private RectSize _baseRectSize;
    public RectSize baseRectSize => _baseRectSize;

    private void Awake()
    {
        _instance = this;
        _baseRectSize = RectSize.FourThree;
    }

    private void Reset()
    {
        tlPoint.gameObject.SetActive(false);
        trPoint.gameObject.SetActive(false);
        blPoint.gameObject.SetActive(false);
        brPoint.gameObject.SetActive(false);
        cPoint.gameObject.SetActive(false);
    }

    public Vector2 GetScreenSize() => backgroundRectTransform.rect.size;
    public RectTransform GetMainRectTransform() => backgroundRectTransform;
}

public enum RectSize { FourThree, SixteenNine }