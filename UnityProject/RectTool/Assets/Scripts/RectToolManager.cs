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

    private void Awake()
    {
        _instance = this;
    }

    public Vector2 GetScreenSize() => backgroundRectTransform.rect.size;
}