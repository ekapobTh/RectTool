using UnityEngine;
using UnityEngine.UI;

public class MenuFile : Menu
{
    [SerializeField] private Button newButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Toggle debugToggle;

    protected override void Awake()
    {
        base.Awake();
        newButton.onClick.AddListener(OnClickNew);
        loadButton.onClick.AddListener(OnClickLoad);
    }

    protected override void Start()
    {
        debugToggle.isOn = DataManager.Instance.data.debug;
        debugToggle.onValueChanged.AddListener(DataManager.Instance.SetDebug);
    }

    private void OnClickNew()
    {
        // TODO check remove current process or not
        Hide();
    }

    private void OnClickLoad()
    {
        DataManager.Instance.ChooseLoadFile();
        Hide();
    }
}