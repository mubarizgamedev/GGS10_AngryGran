using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TaskOpenClose : MonoBehaviour
{
    public float waitToUpAgain = 3f; // Time to wait before bringing the task panel back up
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
        
    }
    private void OnDestroy()
    {
       
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

            StopAllCoroutines();
            StartCoroutine(AutoBringUpAfterDelay(waitToUpAgain));
        }
    }

    void ToggleTaskPanel()
    {
        if (isTaskUp)
        {
            // Bring down
            taskAnimator.SetTrigger("TaskDown");
            taskUpDownImage.sprite = upSprite;
            isTaskUp = false;

            // Start auto up after 2 seconds
            StopAllCoroutines();
            StartCoroutine(AutoBringUpAfterDelay(waitToUpAgain));
        }
        else
        {
            // Bring up
            taskAnimator.SetTrigger("TaskUp");
            taskUpDownImage.sprite = downSprite;
            isTaskUp = true;
        }
    }

    IEnumerator AutoBringUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Only bring up if it's still down
        if (!isTaskUp)
        {
            ToggleTaskPanel();
        }
    }


}
