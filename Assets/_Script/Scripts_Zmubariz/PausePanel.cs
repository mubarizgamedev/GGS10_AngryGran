using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button pauseButton;
    public UnityEvent OnPause;
    public UnityEvent OnResume;
    public UnityEvent OnReset;
    public GameObject pausePanel;

    private void Start()
    {
        pauseButton.onClick.AddListener(() => {
            Interstitial.Instance.StartLoading(() => pausePanel.SetActive(true));
        });

    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        EnemyHandler.canAttackCat = false;
        OnPause?.Invoke();
    }
    public void Resume()
    {
        EnemyHandler.canAttackCat = true;
        Time.timeScale = 1; 
        OnResume?.Invoke(); 
    }
    public void Reset()
    {
        Time.timeScale = 1;
        OnResume?.Invoke();
    }

    public void TimeScale()
    {
        Time.timeScale = 1;
    }
}
