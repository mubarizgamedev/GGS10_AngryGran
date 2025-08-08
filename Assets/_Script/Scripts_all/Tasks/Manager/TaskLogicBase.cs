using UnityEngine;

public abstract class TaskLogicBase : ScriptableObject
{
    protected TaskUI uiInstance;
    int currentProgress = 0;
    protected TaskRuntimeContext context;

    public TaskDataSO taskDataSO;
    public int TotalProgressRequired;
    public bool isCompleted;

    public virtual void StartTask(TaskUI taskUI, GameObject obj)
    {
        uiInstance = taskUI;
        obj.SetActive(true);
        Debug.Log("The object" + obj.name + " is now active.");

        currentProgress = 0;
        UpdateUI();
        Debug.Log($"Current Progress: {0} / {TotalProgressRequired}");
    }

    public virtual void RegisterEvents() { }

    public virtual void UnregisterEvents() { }

    public virtual void CheckProgress()
    {

        currentProgress++;

        Debug.Log($"Current Progress: {currentProgress} / {TotalProgressRequired}");

        if (currentProgress >= TotalProgressRequired)
        {
            TaskCompleted();
        }

        UpdateUI();
    }

    public virtual void TaskCompleted()
    {
        UnregisterEvents();
        isCompleted = true;
        TaskHandler.Instance.OnTaskCompleted(uiInstance);
    }

    protected void UpdateUI()
    {
        if (uiInstance != null)
            uiInstance.UpdateFromData(taskDataSO, currentProgress, TotalProgressRequired);
    }

    public virtual void ResetTaskState()
    {
        currentProgress = 0;
        isCompleted = false;
        Debug.Log("Task state has been reset.");
    }

}
