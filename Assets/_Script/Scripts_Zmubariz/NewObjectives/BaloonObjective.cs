using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonObjective : ObjectiveBase
{
    protected override void ProgressCompleted()
    {
        StartCoroutine(ObjectiveCompleteCoroutine());
    }


    private void Start()
    {
        BallonsBehaviour.OnBalloonPopped += BallonsBehaviour_OnBalloonPopped;

    }

    private void BallonsBehaviour_OnBalloonPopped()
    {
        if (gameObject.activeSelf)
        {
            UpdateProgressCount();

        }
    }

    private void OnDestroy()
    {
        BallonsBehaviour.OnBalloonPopped -= BallonsBehaviour_OnBalloonPopped;
    }

    protected override void OnEnableFunction()
    {
        base.OnEnableFunction();
    }
}
