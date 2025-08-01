using UnityEngine;

public class Restarting : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform playerPositionAtStart;
    public void RestartLatestObjective()
    {
        EnemyHandler.Instance.ResetState();
        player.position = playerPositionAtStart.position;
        player.rotation = playerPositionAtStart.rotation;
    }
}
