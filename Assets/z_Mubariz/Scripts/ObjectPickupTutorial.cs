using UnityEngine;
using UnityEngine.Events;

public class ObjectPickupTutorial : MonoBehaviour
{
    public UnityEvent OnGuideObjectPicked;
    private void Start()
    {
        ObjectPicker.OnGuideObjectPicked += Work;
    }

    private void OnDestroy()
    {
        ObjectPicker.OnGuideObjectPicked -= Work;
    }
    private void Work()
    {
        OnGuideObjectPicked?.Invoke();
    }
}
