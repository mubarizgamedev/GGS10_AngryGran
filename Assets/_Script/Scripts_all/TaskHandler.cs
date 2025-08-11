using UnityEngine;
using System.Collections.Generic;

public class TaskHandler : MonoBehaviour
{
    public static TaskHandler Instance { get; private set; }

    public GameObject multiTaskParent;
    public TaskUI taskPrefab;
    public RectTransform parentTransform;
    public List<TaskLogicBase> tasksList = new();
    public List<GameObject> relevantGameobjects = new();
    public List<GameObject> hintGameobjects = new();
    public Update_UI update_UI;

    private int currentIndex = 0;
    private const int MaxActiveTasks = 3;

    // Track active UIs and their task indexes
    private List<TaskUI> activeTaskUIs = new();
    private List<int> activeTaskIndexes = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            multiTaskParent.SetActive(false);
            foreach (var item in tasksList)
            {
                item.isCompleted = false;
            }
            return;
        }
        Debug.Log("TaskHandler Start");
        multiTaskParent.SetActive(true);

        if (tasksList.Count > 0)
            InstantiateInitialTasks();
    }

    private void InstantiateInitialTasks()
    {
        int taskCount = 0;

        while (taskCount < MaxActiveTasks && currentIndex < tasksList.Count)
        {
            // Find next uncompleted task
            while (currentIndex < tasksList.Count && tasksList[currentIndex].isCompleted)
            {
                currentIndex++; // Skip completed tasks
            }

            if (currentIndex < tasksList.Count)
            {
                InstantiateNextTask(currentIndex);
                taskCount++;
                currentIndex++; // Move to next for future iterations
            }
        }
    }

    private void InstantiateNextTask(int index)
    {
        TaskUI taskUI = Instantiate(taskPrefab, parentTransform);
        GameObject contextObj = relevantGameobjects[index];

        tasksList[index].StartTask(taskUI, contextObj);
        tasksList[index].RegisterEvents();

        activeTaskUIs.Add(taskUI);
        activeTaskIndexes.Add(index);
    }


    public void OnTaskCompleted(TaskUI taskUI)
    {
       
        int index = activeTaskUIs.IndexOf(taskUI);

        if (index >= 0)
        {
            int taskLogicIndex = activeTaskIndexes[index];
            tasksList[taskLogicIndex].isCompleted = true; // Mark as done
            tasksList[taskLogicIndex].UnregisterEvents();

            Destroy(taskUI.gameObject);
            activeTaskUIs.RemoveAt(index);
            activeTaskIndexes.RemoveAt(index);

            if (AdmobAdsManager.Instance.Check_Firebase && Application.internetReachability != NetworkReachability.NotReachable)
            {
                Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_" + index+"Comp");
            }

            GameStateManager.Instance.MissionCompleted();
            PlayerPrefs.SetInt("FirstTaskDone", 1); // Ensure this is set when a task is completed
        }
    }

}
