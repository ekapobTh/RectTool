using UnityEngine;

public class DebugManager : MonoBehaviour
{
    private static DebugManager _instance;
    public static DebugManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<DebugManager>();

            return _instance;
        }
    }

    [SerializeField] private GameObject debugGameObject;

    private void Awake()
    {
        SetDebug(false);
    }

    public void SetDebug(bool isDebug) => debugGameObject.SetActive(isDebug);
}