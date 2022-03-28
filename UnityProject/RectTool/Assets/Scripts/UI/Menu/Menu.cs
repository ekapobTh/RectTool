using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : Button
{
    [SerializeField] private GameObject SubmenuGameObject;

    public void Hide() => SubmenuGameObject?.SetActive(false);

    public void Show() => SubmenuGameObject?.SetActive(true);
}
