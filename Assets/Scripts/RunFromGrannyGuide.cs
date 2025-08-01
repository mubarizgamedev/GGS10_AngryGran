using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunFromGrannyGuide : MonoBehaviour
{
    [SerializeField] Animator guideGrannyAnimator;
    public GameObject congratsPanel;
    public GameObject fadePanel;

    private void OnEnable()
    {
        guideGrannyAnimator.SetBool("AngerStart", true);
        Sound();
        PlayerPrefs.SetInt("Tutorial", 1);
        Invoke(nameof(Call), 4.3f);
    }

    private void Sound()
    {
        SFX_Manager.PlaySound(SFX_Manager.Instance.angryTalkGranny);
    }

    private void Call()
    {
        StartCoroutine(TutorailEndCoroutine());
    }

    IEnumerator TutorailEndCoroutine()
    {
        congratsPanel.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        congratsPanel.SetActive(false);
        fadePanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
