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
        #region Button Setup
        outAreaButton.onClick.RemoveAllListeners();
        outAreaButton.onClick.AddListener(OnOutAreaClick);
        fileButton.onClick.AddListener(OnClickShowOutArea);
        fileButton.onClick.AddListener(() => { HideOtherMenu(fileButton); });
        ImageListButton.onClick.AddListener(OnClickShowOutArea);
        ImageListButton.onClick.AddListener(() => { HideOtherMenu(ImageListButton); });
        #endregion

        HideOtherMenu(null);
    }

    private void OnClickShowOutArea() => outAreaButton.gameObject.SetActive(true);
    private void OnOutAreaClick()
    {
        fileButton.Hide();
        ImageListButton.Hide();
        outAreaButton.gameObject.SetActive(false);
    }

    private void HideOtherMenu(Menu except)
    {
        if (!fileButton.Equals(except))
            fileButton.Hide();
        if (!ImageListButton.Equals(except))
            ImageListButton.Hide();
    }
}