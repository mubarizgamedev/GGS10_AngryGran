public class GiftObjectives : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }

    private void Start()
    {
        ChristmasGifts.OnGifthitGranny += ChristmasGifts_OnGifthitGranny;
    }

    private void ChristmasGifts_OnGifthitGranny()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();
            
        }
    }

    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();
        
    }

    private void OnDestroy()
    {
        ChristmasGifts.OnGifthitGranny -= ChristmasGifts_OnGifthitGranny;
    }
}
