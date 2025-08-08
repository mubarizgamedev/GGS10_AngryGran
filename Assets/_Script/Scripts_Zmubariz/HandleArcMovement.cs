using UnityEngine;
using UnityEngine.UI;

public class HandleArcMovement : MonoBehaviour
{
    public RectTransform handleUI;
    public RectTransform centerPoint;
    public float radius = 100f;
    public Slider zoomSlider;

    void Start()
    {
        if (zoomSlider != null)
            zoomSlider.value = 0f;
    }

    void Update()
    {
        if (zoomSlider == null) return;

        // Directly use slider value, assuming it goes from 0 to 1 only
        float zoomPercent = Mathf.Clamp01(zoomSlider.value);

        // Lerp from 90° (top) to 270° (bottom)
        float angle = Mathf.Lerp(90f, 270f, zoomPercent);
        float rad = angle * Mathf.Deg2Rad;

        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
        handleUI.localPosition = offset;
    }
}
