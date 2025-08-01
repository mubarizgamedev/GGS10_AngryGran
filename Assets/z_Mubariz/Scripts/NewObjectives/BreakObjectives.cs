
public class BreakObjectives : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }

    private void Start()
    {
        Breakable.OnBreakObject += Breakable_OnBreakObject;
    }
    private void OnDestroy()
    {
        Breakable.OnBreakObject -= Breakable_OnBreakObject;
    }

    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();

    }
    private void Breakable_OnBreakObject()
    {
        UpdateProgressCount();
    }
}
