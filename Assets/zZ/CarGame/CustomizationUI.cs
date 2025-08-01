using UnityEngine.UI;
using UnityEngine;

public class CustomizationUI : MonoBehaviour
{
    public CameraMovement cameraFocus;
    public Transform tireTarget;
    public Transform bodyTarget;
    public Transform bottomTarget;
    public Transform hoodTarget;

    public Button tyreFocus;
    public Button hoodFocus;
    public Button bodyFocus;
    public Button bottomFocus;


    private void Start()
    {
        tyreFocus.onClick.AddListener(FocusOnTires);
        hoodFocus.onClick.AddListener(FocusOnHood);
        bodyFocus.onClick.AddListener(FocusOnBody);
        bottomFocus.onClick.AddListener(FocusOnBottom);
    }

    public void FocusOnTires()
    {
        cameraFocus.SetFocusTarget(tireTarget);
    }

    public void FocusOnBody()
    {
        cameraFocus.SetFocusTarget(bodyTarget);
    }
    
    public void FocusOnBottom()
    {
        cameraFocus.SetFocusTarget(bottomTarget);
    }
    
    public void FocusOnHood()
    {
        cameraFocus.SetFocusTarget(hoodTarget);
    }
}
