using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageListController : MonoBehaviour
{
    private const int BACKGROUND_INDEX = 0;

    private List<SubImageListCell> m_SubImageListCells = new List<SubImageListCell>();
    public SubImageListCell backgroundCell 
    {
        get
        {
            if (m_SubImageListCells != null && m_SubImageListCells.Count > 0)
                return m_SubImageListCells[BACKGROUND_INDEX];
            return null;
        }
    }

    private void Awake()
    {
        Reset();
    }

    private void Reset()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}