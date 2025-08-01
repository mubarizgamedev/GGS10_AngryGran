using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;

    private Transform currentTarget;

    void Update()
    {
        if (currentTarget != null)
        {
            // Smooth position
            //transform.position = Vector3.Lerp(transform.position, currentTarget.position, Time.deltaTime * moveSpeed);
            transform.position = Vector3.Slerp(transform.position, currentTarget.position, Time.deltaTime * moveSpeed);

            // Smooth rotation
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }

    public void SetFocusTarget(Transform target)
    {
        currentTarget = target;
    }
}
