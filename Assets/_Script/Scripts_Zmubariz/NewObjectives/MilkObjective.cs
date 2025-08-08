public class MilkObjective : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }


    private void Start()
    {
        MilkTrigger.OnCatDrink += MilkTrigger_OnCatDrink;
    }
    private void OnDestroy()
    {
        MilkTrigger.OnCatDrink -= MilkTrigger_OnCatDrink;
    }
    private void MilkTrigger_OnCatDrink()
    {
        UpdateProgressCount();
    }

    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();

    }

}
