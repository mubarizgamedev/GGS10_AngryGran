
using UnityEngine;

[CreateAssetMenu(menuName = "TaskLogic/DiamondTask")]
public class DiamondsTask : TaskLogicBase
{
    private bool isRegistered = false;
    public override void RegisterEvents()
    {
        PlayerCollisionEvents.OnDiamondHit -= Check;
        PlayerCollisionEvents.OnDiamondHit += Check;
    }

    void Check()
    {
        CheckProgress();
    }

    public override void UnregisterEvents()
    {
        PlayerCollisionEvents.OnDiamondHit -= Check;
    }
    private void OnDestroy()
    {
        PlayerCollisionEvents.OnDiamondHit -= Check;
    }

}
