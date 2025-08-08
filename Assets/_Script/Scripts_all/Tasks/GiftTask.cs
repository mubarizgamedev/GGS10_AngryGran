using UnityEngine;
[CreateAssetMenu(menuName = "TaskLogic/GiftTask")]
public class GiftTask : TaskLogicBase
{
    private bool isRegistered = false;
    public override void RegisterEvents()
    {
        ChristmasGifts.OnGifthitGranny -= ChristmasGifts_OnGifthitGranny;
        ChristmasGifts.OnGifthitGranny += ChristmasGifts_OnGifthitGranny;
    }

    private void ChristmasGifts_OnGifthitGranny()
    {
        CheckProgress();
    }


    public override void UnregisterEvents()
    {
        ChristmasGifts.OnGifthitGranny -= ChristmasGifts_OnGifthitGranny;
    }

    private void OnDestroy()
    {
        ChristmasGifts.OnGifthitGranny -= ChristmasGifts_OnGifthitGranny;
    }
}
