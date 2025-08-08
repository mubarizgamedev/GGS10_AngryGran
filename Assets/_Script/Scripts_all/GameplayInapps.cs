using UnityEngine;
using UnityEngine.UI;

public class GameplayInapps : MonoBehaviour
{
    public Button btnBuyAll;
    public Button btnBuyAllCat;

    private void Start()
    {
        btnBuyAll.onClick.AddListener(()=> GameAppManager.instance.Btn_Buy_Everything());
        btnBuyAllCat.onClick.AddListener(() => GameAppManager.instance.Unlock_All_Pets());
    }
}
