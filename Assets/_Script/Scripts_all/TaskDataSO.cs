using UnityEngine;

[CreateAssetMenu(fileName = "NewTaskData", menuName = "ScriptableObjects/TaskData", order = 1)]
public class TaskDataSO : ScriptableObject
{
    public Sprite taskImage;
    public string taskTitle;
    public string description;
    public int reward;
    public bool isTaskCompleted;

    public string hintText;
}
