using UnityEngine;

[CreateAssetMenu(menuName = "TaskLogic/KeyTask")]
public class KeyTask : TaskLogicBase
{
    public override void RegisterEvents()
    {

        PlayerCollisionEvents.OnKeyHit -= PlayerCollisionEvents_OnKeyHit;
        PlayerCollisionEvents.OnKeyHit += PlayerCollisionEvents_OnKeyHit;
    }

    private void PlayerCollisionEvents_OnKeyHit()
    {
        CheckProgress();
    }

    public override void UnregisterEvents()
    {
        PlayerCollisionEvents.OnKeyHit -= PlayerCollisionEvents_OnKeyHit;
    }
    private void OnDestroy()
    {
        PlayerCollisionEvents.OnKeyHit -= PlayerCollisionEvents_OnKeyHit;
    }
}
