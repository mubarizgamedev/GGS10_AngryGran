using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ObjectivesCutscene : MonoBehaviour
{
    private PlayableDirector m_PlayableDirector;
    public bool updateUIenable;
    public UnityEvent OnCutSceneStart;
    public UnityEvent OnCutSceneEnd;
    public GameObject updateUI;

    public Button skipButton;

    private void OnEnable()
    {
        m_PlayableDirector = GetComponent<PlayableDirector>();

        if (m_PlayableDirector)
        {
            m_PlayableDirector.played += M_PlayableDirector_played;
            m_PlayableDirector.stopped += M_PlayableDirector_stopped;
            m_PlayableDirector.Play();
        }
        else
        {
            Debug.LogWarning("PlayableDirector component not found.");
        }
        skipButton.onClick.AddListener(SkipCutScene);
    }

    private void OnDisable()
    {
        if (m_PlayableDirector)
        {
            m_PlayableDirector.played -= M_PlayableDirector_played;
            m_PlayableDirector.stopped -= M_PlayableDirector_stopped;
        }
    }

    private void M_PlayableDirector_played(PlayableDirector obj)
    {
        Debug.Log("Cutscene Started");
        OnCutSceneStart?.Invoke();
    }

    public void M_PlayableDirector_stopped(PlayableDirector obj)
    {
        Debug.Log("Cutscene Ended");
        OnCutSceneEnd?.Invoke();
        gameObject.SetActive(false);
    }

    void SkipCutScene()
    {
        Interstitial.Instance.StartLoading(RealWork);
    }

    void RealWork()
    {
        m_PlayableDirector.Resume();
        m_PlayableDirector.Stop();
        skipButton.gameObject.SetActive(false);
        Debug.Log("Cutscene Ended");
        OnCutSceneEnd?.Invoke();
        gameObject.SetActive(false);
        if (updateUIenable)
        {
            Invoke(nameof(UpdateUIEnable), 1f);
        } 
    }

    void UpdateUIEnable()
    {
        updateUI?.SetActive(true);
    }
}
