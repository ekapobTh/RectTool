using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController _instance;
    public static UIController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIController>();

            return _instance;
        }
    }

    [SerializeField] private Button outAreaButton;

    [Header("Menu Button")]
    [SerializeField] private MenuFile fileButton;
    [SerializeField] private MenuImageList ImageListButton;

    public void Awake()
    {
        fileButton.onClick.RemoveAllListeners();
        fileButton.onClick.AddListener(OnFileClick);
        ImageListButton.onClick.RemoveAllListeners();
        ImageListButton.onClick.AddListener(OnImageListClick);
    }

    public void OnFileClick()
    {
        // Show File Menu new load set bg
    }

    public void OnImageListClick()
    {
        // Show Side Image
    }
}
