
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public Button mainmenuPlay;
    public Button exitButton;
    public Button grannySelectButton;
    public Button settingButton;
    public GameObject exitPanel;
    public GameObject mainmenuPanel;
    public GameObject settingPanel;
    public GameObject petSelectionPanel;

    private void Start()
    {
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingButton.onClick.AddListener(OnSettingPressed);
        mainmenuPlay.onClick.AddListener(OnPlayButtonClicked);
        grannySelectButton.onClick.AddListener(OnGrannySelectButtonClicked);
    }

    void OnSettingPressed()
    {
        Interstitial.Instance.StartLoading(() =>
        {
            settingPanel.SetActive(true);
            mainmenuPanel.SetActive(false);
        });
    }

    void OnExitButtonClicked()
    {
        Interstitial.Instance.StartLoading(() => 
        {
            exitPanel.SetActive(true);
            mainmenuPanel.SetActive(false);
        });
    }

    void OnPlayButtonClicked()
    {
        Interstitial.Instance.StartLoading(() =>
        {
            mainmenuPanel.SetActive(false);
            petSelectionPanel.SetActive(true);
        });
    }

    void OnGrannySelectButtonClicked()
    {
        Debug.Log("Granny Select Button Clicked");
        Interstitial.Instance.StartLoading(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GG_Gameplay");
        }, true);
    }
}
