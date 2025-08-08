using UnityEngine;

[CreateAssetMenu(menuName = "TaskLogic/BaloonTask")]

public class BaloonTask : TaskLogicBase
{
    public override void RegisterEvents()
    {
        BallonsBehaviour.OnBalloonPopped -= BallonsBehaviour_OnBalloonPopped;
        BallonsBehaviour.OnBalloonPopped += BallonsBehaviour_OnBalloonPopped;
    }

    private void BallonsBehaviour_OnBalloonPopped()
    {
        CheckProgress();
    }

    public override void UnregisterEvents()
    {
        BallonsBehaviour.OnBalloonPopped -= BallonsBehaviour_OnBalloonPopped;
    }
    private void OnDestroy()
    {
        BallonsBehaviour.OnBalloonPopped -= BallonsBehaviour_OnBalloonPopped;
    }
}
