using UnityEngine;
using UnityEngine.UI;

public class Menu : Button
{
    [SerializeField] private GameObject SubmenuGameObject;

    protected override void Awake()
    {
        onClick.AddListener(Show);
    }

    public void Hide()
    {
        if(SubmenuGameObject != null)
            SubmenuGameObject?.SetActive(false);
    }

    public void Show()
    {
        if (SubmenuGameObject != null)
            SubmenuGameObject?.SetActive(true);
    }
}