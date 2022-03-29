using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : Button
{
    [SerializeField] private GameObject SubmenuGameObject;

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
