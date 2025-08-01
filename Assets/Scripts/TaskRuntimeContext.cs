using UnityEngine;

public class TaskRuntimeContext : MonoBehaviour
{
    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;

    public void Activate()
    {
        foreach (var go in objectsToEnable)
            if (go != null) go.SetActive(true);

        foreach (var go in objectsToDisable)
            if (go != null) go.SetActive(false);
    }

    public void Deactivate()
    {
        foreach (var go in objectsToEnable)
            if (go != null) go.SetActive(false);

        foreach (var go in objectsToDisable)
            if (go != null) go.SetActive(true);
    }
}
