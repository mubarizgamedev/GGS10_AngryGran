
public class BreakGlassObjective : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }

    private void Start()
    {
        Breakable.OnBreakGlass += Breakable_OnGlassBreak;
    }

    private void Breakable_OnGlassBreak()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();
        }
    }

    private void OnDestroy()
    {
        Breakable.OnBreakGlass -= Breakable_OnGlassBreak;
    }

    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();
    }

}
