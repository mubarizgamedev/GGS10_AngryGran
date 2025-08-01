using UnityEngine;

public class SelectedEnemyCheck : MonoBehaviour
{
    int selectedIndexForGranny;
    public static SelectedEnemyCheck Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }
    private void Start()
    {
        selectedIndexForGranny = PlayerPrefs.GetInt("SelectedGrannyIndex", 0);
    }
    public int IsGrannySelected()
    {
        return selectedIndexForGranny;
    }
}
