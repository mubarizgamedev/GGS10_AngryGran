using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    [Header("LINKS")]
    public string privacyPolicyLink;
    public string moreGamesLink;
    public string rateUsLink;

    [Space(5)]
    [Header("BUTTONS")]
    public Button btnPrivacyPolicy;
    public Button btnMoreGames;
    public Button btnRateUs;
    public Button btnSettingBack;
    [Space(2)]
    public Button btnQuitYes;
    public Button btnQuitNo;

    [Space(5)]
    [Header("PANELS")]
    public GameObject mainmenuPanel;
    public GameObject petSelectionMenu;
    public GameObject settingPanel;
    public GameObject quitPanel;

    private void Start()
    {
        btnPrivacyPolicy.onClick.AddListener(() => OpenLink(privacyPolicyLink));
        btnMoreGames.onClick.AddListener(() => OpenLink(moreGamesLink));
        btnRateUs.onClick.AddListener(() => OpenLink(rateUsLink));
        btnSettingBack.onClick.AddListener(() => settingPanel.SetActive(false));
        btnQuitNo.onClick.AddListener(() => quitPanel.SetActive(false));
        btnQuitYes.onClick.AddListener(() => Application.Quit());
    }

    void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
