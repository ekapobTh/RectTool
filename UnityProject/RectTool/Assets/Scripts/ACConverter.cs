﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ACConverter : MonoBehaviour
{
    [MenuItem("Tools/RectTransform/Anchors to Corners %[")]
    static void AnchorsToCorners()
    {
        var obj = Selection.transforms;
        Undo.RegisterCompleteObjectUndo(obj, "Anchors to Corners");
        foreach (var item in obj)
        {
            var t = item as RectTransform;
            var pt = item.parent as RectTransform;
            if (t == null || pt == null)
                continue;
            AnchorToCorners();

            void AnchorToCorners()
            {
                Vector2 newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                                    t.anchorMin.y + t.offsetMin.y / pt.rect.height);
                Vector2 newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                                    t.anchorMax.y + t.offsetMax.y / pt.rect.height);

                t.anchorMin = newAnchorsMin;
                t.anchorMax = newAnchorsMax;
                t.offsetMin = t.offsetMax = new Vector2(0, 0);
            }
        }
    }
}
