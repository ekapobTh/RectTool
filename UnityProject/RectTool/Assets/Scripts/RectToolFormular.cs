using UnityEngine;

public static class RectToolFormular
{
    public static Vector2 ComponentMultiply(this Vector2 v, Vector2 other) => new Vector2(v.x * other.x, v.y * other.y);
}