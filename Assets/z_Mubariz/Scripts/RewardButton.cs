using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{

    public GameObject currentRewardedGameobject;
    [SerializeField] PlayerRaycaster playerRaycaster;
    [SerializeField] AdAfter40Sec AdAfter40Sec;
    public Button rewardButton;




    private void Start()
    {
        playerRaycaster.OnInteractedWithRewarded += PlayerRaycaster_OnInteractedWithRewarded;
        rewardButton.onClick.AddListener(Btn_Reward);
    }
    private void OnDestroy()
    {
        playerRaycaster.OnInteractedWithRewarded -= PlayerRaycaster_OnInteractedWithRewarded;
    }

    private void PlayerRaycaster_OnInteractedWithRewarded(object sender, PlayerRaycaster.OnInteractedWithRewardedClass e)
    {
        currentRewardedGameobject = e.rewardedGameObject;
    }

    public void Btn_Reward()
    {
        Rewad_.Instance.StartLoading(ActionReward);
    }
    
    void ActionReward()
    {
        currentRewardedGameobject.layer = 8;
        AdAfter40Sec.ResetAdTimer();
    }
}