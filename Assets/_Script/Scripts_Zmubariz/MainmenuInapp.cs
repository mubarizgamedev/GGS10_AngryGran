using UnityEngine.UI;
using UnityEngine;

public class MainmenuInapp : MonoBehaviour
{
    public Button mainBigInappAll;

    private void Start()
    {
        mainBigInappAll.onClick.AddListener(() => GameAppManager.instance.Btn_Buy_Everything());
    }
}
