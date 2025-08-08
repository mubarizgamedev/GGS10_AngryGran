
using UnityEngine;
[CreateAssetMenu(menuName = "TaskLogic/ObjThrowTask")]
public class ObjThrowTask : TaskLogicBase
{
    private bool isRegistered = false;
    public override void RegisterEvents()
    {
        EnemyHandler.canAttackCat = true;
        PickableObject.OnObjHitGranny -= PickableObject_OnGuideObjectHitGranny;
        PickableObject.OnObjHitGranny += PickableObject_OnGuideObjectHitGranny;
    }

    private void PickableObject_OnGuideObjectHitGranny()
    {
        CheckProgress();

    }

    public override void UnregisterEvents()
    {
        PickableObject.OnObjHitGranny -= PickableObject_OnGuideObjectHitGranny;
    }

    private void OnDestroy()
    {
        PickableObject.OnObjHitGranny -= PickableObject_OnGuideObjectHitGranny;
    }
}
