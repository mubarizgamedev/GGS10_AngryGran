public class DiamondObjective : ObjectiveBase
{

    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }

    private void Start()
    {
        PlayerCollisionEvents.OnDiamondHit += PlayerCollisionEvents_OnDiamondHit;
    }

    private void PlayerCollisionEvents_OnDiamondHit()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();

        }
    }

    private void OnDestroy()
    {
        PlayerCollisionEvents.OnDiamondHit -= PlayerCollisionEvents_OnDiamondHit;
    }

    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();
    }
}
