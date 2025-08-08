using UnityEngine;
[CreateAssetMenu(menuName = "TaskLogic/ToysThrowTask")]
public class ToysThrowTask : TaskLogicBase
{
    private bool isRegistered = false;
    public override void RegisterEvents()
    {

            Toy.OnToyHitGranny -= Toy_OnToyHitGranny;
            Toy.OnToyHitGranny += Toy_OnToyHitGranny;
    }

    public override void UnregisterEvents()
    {

        Toy.OnToyHitGranny -= Toy_OnToyHitGranny;

    }

    private void Toy_OnToyHitGranny()
    {
        CheckProgress();
    }
    private void OnDestroy()
    {
        Toy.OnToyHitGranny -= Toy_OnToyHitGranny;
    }
}
