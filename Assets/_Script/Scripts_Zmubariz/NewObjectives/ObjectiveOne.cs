public class ObjThrowObjective : ObjectiveBase
{
    private void Start()
    {
        EnemyHandler.canAttackCat = true;
        PickableObject.OnObjHitGranny += PickableObject_OnGuideObjectHitGranny;
    }

    private void PickableObject_OnGuideObjectHitGranny()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();
        }
       
    }

    private void OnDestroy()
    {
        PickableObject.OnObjHitGranny -= PickableObject_OnGuideObjectHitGranny;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        NewObjectiveManager.Instance.ChangeAnimatorToWandering();
    }
    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();
    }



    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }
}
