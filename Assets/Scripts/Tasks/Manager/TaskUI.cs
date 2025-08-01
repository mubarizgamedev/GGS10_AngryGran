using System;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    public Image taskImage;
    public Text taskText;
    public Text descriptionText;
    public Text totalProgress;
    public Text currentProgress;

    public Button HintButton;

    string hintText;

    public static event Action<string> OnHintRequested;
    public void UpdateFromData(TaskDataSO data, int current, int total)
    {
        taskImage.sprite = data.taskImage;
        taskText.text = data.taskTitle;
        descriptionText.text = data.description;
        totalProgress.text = total.ToString();
        currentProgress.text = current.ToString();
        hintText = data.hintText;
    }


    private void Start()
    {
        HintButton.onClick.AddListener(Hint);
    }
    void Hint()
    {
        OnHintRequested?.Invoke(hintText);
    }
}
