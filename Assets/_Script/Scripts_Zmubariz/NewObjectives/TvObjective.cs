public class TvObjective : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }

    private void Start()
    {
        Remote.OnInteract += Remote_OnInteract;
    }

    private void Remote_OnInteract()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();
        }
    }

    private void OnDestroy()
    {
        Remote.OnInteract -= Remote_OnInteract;
    }
    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();
    }
}
