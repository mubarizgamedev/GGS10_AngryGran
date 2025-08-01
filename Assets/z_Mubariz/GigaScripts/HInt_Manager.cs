using UnityEngine;
using UnityEngine.UI;
public class HInt_Manager : MonoBehaviour
{
    public Button hintActiveButton;

    private void Start()
    {
        hintActiveButton.onClick.AddListener(HintButtonClicked);
    }

    private void HintButtonClicked()
    {
        Rewad_.Instance.StartLoading(ActionToDo);
    }

    void ActionToDo()
    {
        NewObjectiveManager.Instance.IndicatorHint();
    }
}
