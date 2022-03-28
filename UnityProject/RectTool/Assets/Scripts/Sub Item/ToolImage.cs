using UnityEngine;
using UnityEngine.UI;

public class ToolImage : MonoBehaviour
{
    [SerializeField] protected Image m_Image;

    public void SetupImage(Sprite sprite)
    {
        m_Image.sprite = sprite;
        m_Image.color = Color.white;
    }

    public virtual void Reset()
    {
        m_Image.sprite = null;
    }
}