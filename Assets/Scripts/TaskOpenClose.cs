using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TaskOpenClose : MonoBehaviour
{
    public Button taskUpDown;
    public Animator taskAnimator;
    public Sprite upSprite;
    public Sprite downSprite;
    public Image taskUpDownImage;

    bool nowUp;
    float restTime;
    bool isTaskUp;
    private void Start()
    {
        taskUpDown.onClick.AddListener(ToggleTaskPanel);
        TouchCheck.OnTouch += UpTask;
    }
    private void OnDestroy()
    {
        TouchCheck.OnTouch -= UpTask;
    }

    
    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("FirstTaskDone", 0) == 0)
        {
            taskAnimator.SetTrigger("TaskUp");
            taskUpDownImage.sprite = downSprite;
            taskUpDownImage.enabled = false;
            isTaskUp = true;
        }
        else
        {
            taskAnimator.SetTrigger("TaskDown");
            taskUpDownImage.sprite = upSprite;
            taskUpDownImage.enabled = true;
            isTaskUp = false;
        }
    }

    void ToggleTaskPanel()
    {
        if(isTaskUp)
        {
            taskAnimator.SetTrigger("TaskDown");
            taskUpDownImage.sprite = upSprite;
            isTaskUp = false;
        }
        else
        {
            taskAnimator.SetTrigger("TaskUp");
            taskUpDownImage.sprite = downSprite;
            isTaskUp = true;
        }
    }

    void UpTask()
    {
        Invoke(nameof(Work), restTime);
    }
    void Work()
    {
        StartCoroutine(NowUpCoroutine());
    }

    IEnumerator NowUpCoroutine()
    {
        yield return new WaitForSeconds(5f);
        if (!isTaskUp)
        {
            taskAnimator.SetTrigger("TaskUp");
            taskUpDownImage.sprite = downSprite;
            isTaskUp = true;
            Debug.Log("Now task Up");
        }
    }

}
