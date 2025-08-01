using UnityEngine;

public class EnabelRightGranInGameplay : MonoBehaviour
{
    public Animator grannyAnimator;

    public Avatar[] grannyAvatar;
    public GameObject[] allGrans;

    private void OnEnable()
    {
        Invoke(nameof(EnableWriteGranny), 0.15f);
    }

    void EnableWriteGranny()
    {
        if(allGrans == null || allGrans.Length == 0)
        {
            Debug.LogWarning("No granny objects assigned in EnabelRightGranInGameplay.");
            return;
        }

        foreach (var item in allGrans)
        {
            item.SetActive(false); // Disable all granny objects
        }
        
        Debug.Log("Latest unlocked Granny is : " + SelectedEnemyCheck.Instance.IsGrannySelected());
        allGrans[SelectedEnemyCheck.Instance.IsGrannySelected()].SetActive(true); // Enable the selected granny
        grannyAnimator.avatar = grannyAvatar[SelectedEnemyCheck.Instance.IsGrannySelected()]; // Set the animator avatar
    }
}
