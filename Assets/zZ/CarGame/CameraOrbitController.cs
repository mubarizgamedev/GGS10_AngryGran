using UnityEngine;
using UnityEngine.EventSystems;

public class CameraOrbitController : MonoBehaviour
{
    public Transform target;
    public RectTransform dragAreaUI; // 🎯 Assign your centered panel in Inspector

    public float distance = 5f;
    public float xSpeed = 120f;
    public float ySpeed = 120f;
    public float yMinLimit = 10f;
    public float yMaxLimit = 80f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void LateUpdate()
    {
        if (target == null || dragAreaUI == null) return;

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(0) &&
            RectTransformUtility.RectangleContainsScreenPoint(dragAreaUI, Input.mousePosition))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        }

#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved &&
                RectTransformUtility.RectangleContainsScreenPoint(dragAreaUI, touch.position))
            {
                Vector2 delta = touch.deltaPosition;
                x += delta.x * xSpeed * 0.02f * Time.deltaTime;
                y -= delta.y * ySpeed * 0.02f * Time.deltaTime;
            }
        }
#endif

        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}
