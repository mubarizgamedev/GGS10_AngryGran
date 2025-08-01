using UnityEngine;
using System;
using UnityEngine.UI;

public class SpecialManager : MonoBehaviour
{
    [Header("Boxing")]
    [SerializeField] GameObject fireRewardPanel;
    [SerializeField] GameObject beeRewardPanel;
    [SerializeField] GameObject currentRewardPanel;
    [SerializeField] GameObject boxingRewardPanel;
    [Space(10)]
    [SerializeField] GameObject playerBoxingGlove;
    [SerializeField] GameObject playerShockGun;
    [Header("UI Button")]
    [SerializeField] GameObject boxingUI;
    [SerializeField] GameObject ShockGunUI;
    [SerializeField] GameObject fireButtonUI;
    [SerializeField] GameObject beeButtonUI;
    [Space(5)]
    [Header("UI Button")]
    [SerializeField] Button boxingGetButton;
    [SerializeField] Button currentGetButton;
    [SerializeField] Button fireGetButton;
    [SerializeField] Button beeGetButton;



    private void Start()
    {
        AssigningGameplayButtons();

        PlayerCollisionEvents.OnPuchBoxTrigger += OnPunchButtonPressed;
        PlayerCollisionEvents.OnShockGunTrigger += OnShockButtonPressed;
    }
    private void OnDestroy()
    {
        PlayerCollisionEvents.OnPuchBoxTrigger -= OnPunchButtonPressed;
        PlayerCollisionEvents.OnShockGunTrigger -= OnShockButtonPressed;
    }


    //Gameplay Buttons 
    public void OnShockButtonPressed()
    {
        currentRewardPanel.SetActive(true);
    }

    public void OnPunchButtonPressed()
    {
        boxingRewardPanel.SetActive(true);
    }

    public void OnFireButtonPressed()
    {
        fireRewardPanel.SetActive(true);
    }
    public void OnBeeButtonPressed()
    {
        beeRewardPanel.SetActive(true);
    }

    void AssigningGameplayButtons()
    {
        boxingGetButton.onClick.AddListener(RewardForPunch);
        currentGetButton.onClick.AddListener(RewardForCurrent);
        fireGetButton.onClick.AddListener(RewardForFire);
        beeGetButton.onClick.AddListener(RewardForBee);
    }


    

    void RewardForBee()
    {
        Rewad_.Instance.StartLoading(ActionAfterBeeReward);
    }

    void RewardForFire()
    {
        Rewad_.Instance.StartLoading(ActionAfterFireReward);
    }

    void RewardForPunch()
    {
        Rewad_.Instance.StartLoading(ActionAfterBoxingReward);
    }

    void RewardForCurrent()
    {
        Rewad_.Instance.StartLoading(ActionAfterShockReward);
    }

   

    
    void ActionAfterBoxingReward()
    {
        boxingRewardPanel.SetActive(false);
        playerBoxingGlove.SetActive(true);
        SpecialItemInHand.Instance.SetItemState(playerBoxingGlove, true);
        boxingUI.SetActive(true);
    }

   
    void ActionAfterShockReward()
    {
        currentRewardPanel.SetActive(false);
        ShockGunUI.SetActive(true);
        playerShockGun.SetActive(true);
        SpecialItemInHand.Instance.SetItemState(playerShockGun, true);
    }

    
    void ActionAfterFireReward()
    {
        fireRewardPanel.SetActive(false);
        fireButtonUI.SetActive(true);
        playerShockGun.SetActive(true);
        SpecialItemInHand.Instance.SetItemState(playerShockGun, true);
    }

    
    void ActionAfterBeeReward()
    {
        beeRewardPanel.SetActive(false);
        beeButtonUI.SetActive(true);
        playerShockGun.SetActive(true);
        SpecialItemInHand.Instance.SetItemState(playerShockGun, true);
    }

    public void DisableAllPanels()
    {
        boxingRewardPanel.SetActive(false);
        currentRewardPanel.SetActive(false);
        fireRewardPanel.SetActive(false);
        beeRewardPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BoxUIButtonPressed()
    {
        SpecialItemInHand.Instance.SetItemState(playerBoxingGlove, false);
    }

    public void GuncUIButtonPressed()
    {
        SpecialItemInHand.Instance.SetItemState(playerShockGun, false);
    }
}
