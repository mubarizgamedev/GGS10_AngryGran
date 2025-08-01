public class KeyObjective : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }

    private void Start()
    {
        PlayerCollisionEvents.OnKeyHit += PlayerCollisionEvents_OnKeyHit;

    }

    private void PlayerCollisionEvents_OnKeyHit()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();
        }
    }

    private void OnDestroy()
    {
        PlayerCollisionEvents.OnKeyHit -= PlayerCollisionEvents_OnKeyHit;
    }
}
