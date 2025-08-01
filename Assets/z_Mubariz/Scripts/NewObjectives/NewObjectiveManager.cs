using UnityEngine;

public class NewObjectiveManager : MonoBehaviour
{
    public static NewObjectiveManager Instance;

    [Header("Shared Components")]
    public Main_Quest mainQuest;
    public Update_UI updateUI;
    public Items_Count itemsCount;

    [Header("UI & Audio")]
    public GameObject fadeObject;
    public AudioClip completeClip;
    public AudioClip progressClip;

    [Space(5)]
    [Header("Player")]
    public Transform petTransfrom;
    public Transform petEyesCamera;
    public GameObject rayCaster;

    [Header("Granny")]
    public Transform granny;
    public Animator grannyAnimator;
    public RuntimeAnimatorController grannyWanderingAnimator;
    public RuntimeAnimatorController garnnyWatchingTvAnimator;
    public RuntimeAnimatorController grannyCookingAnimator;
    public GameObject[] allGranniesBats;
    public GameObject grannyWanderingControllerGo;
    public GameObject tutorialGranny;
    public EnemyWandering enemyWandering;

    
    [Space(5)]
    [Header("Gameobjects Refrence")]
    public GameObject[] uiObjToActivate;

    [Header("Level Objectives")]
    public GameObject[] levelObjectives;
    [HideInInspector]
    public ObjectiveBase currentObjective;

    public EnemyHandler enemyHandler;
    public GameObject currentLevelGameobject;
    string localString;
    
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void ChangeAnimatorToSit()
    {
        grannyAnimator.runtimeAnimatorController = garnnyWatchingTvAnimator;
    }

    public void ChangeAnimatorToStandWorking()
    {
        grannyAnimator.runtimeAnimatorController = grannyCookingAnimator;
    }
    public void ChangeAnimatorToWandering()
    {
        grannyAnimator.runtimeAnimatorController = grannyWanderingAnimator;
    }
    public void EnableRayCaster(bool condition)
    {
        rayCaster.SetActive(condition);
    }


  
    public void ResetGrannyState()
    {
        enemyHandler.isChasingCat = false;
        enemyHandler.ResetState();
    }

    public void GranniesBats(bool condition)
    {
        foreach (var item in allGranniesBats)
        {
            item.SetActive(condition);
        }
    }

    public void AdCoinsOnLevelComplete()
    {
        itemsCount.Ad50Coins();
    }
    int GetActiveChildIndex(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            Transform child = parent.transform.GetChild(i);

            if (child.gameObject.activeInHierarchy)
            {
                return i; // Return index of the active child
            }
        }

        return -1; // No active child found
    }

    public int CurrentLevel()
    {
        int currentlevel = GetActiveChildIndex(gameObject) + 1;
        return currentlevel;
    }

    public void IndicatorHint()
    {
        ObjectiveBase currentGo = currentLevelGameobject.GetComponent<ObjectiveBase>();
        if (currentGo)
        {
            currentGo.EnableIndicatorGameobjects();
        }
    }
    public void DisableHintObjects()
    {
        ObjectiveBase currentGo = currentLevelGameobject.GetComponent<ObjectiveBase>();
        if (currentGo)
        {
            currentGo.DisableIndicatorGameobjects();
        }
    }

}
