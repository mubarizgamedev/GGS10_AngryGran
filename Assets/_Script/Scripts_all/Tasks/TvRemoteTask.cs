
using UnityEngine;


[CreateAssetMenu(menuName = "TaskLogic/TVTask")]
public class TvRemoteTask : TaskLogicBase
{
    public override void RegisterEvents()
    {
        Remote.OnInteract -= RemoteInteract;
        Remote.OnInteract += RemoteInteract;
    }

    public override void UnregisterEvents()
    {

        Remote.OnInteract -= RemoteInteract;
    }

    private void RemoteInteract()
    {
        CheckProgress();
    }
    private void OnDestroy()
    {
        Remote.OnInteract -= RemoteInteract;
    }
}
