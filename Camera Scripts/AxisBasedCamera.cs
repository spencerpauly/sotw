using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisBasedCamera : PlayerCamera {

    private Vector3 desiredPosition;
    private Vector3 playerViewOffset;    
    private Vector3 offset;

    void Start() {
        offset = new Vector3(0, cameraDistance * Mathf.Sin(Mathf.Deg2Rad*cameraAngle), -cameraDistance * Mathf.Cos(Mathf.Deg2Rad*cameraAngle));
        playerViewOffset = new Vector3(0.0f, cameraOffset, 0.0f);
    }

    void Update() {

        //Vector3 normalizedOffset = offset.normalized;

        offset = new Vector3(offset.x, offset.magnitude * Mathf.Sin(Mathf.Deg2Rad * cameraAngle), offset.z);
        if (cameraDistance != offset.magnitude) {
            offset = offset.normalized * cameraDistance;
        }
        
    }

    void LateUpdate() {
        if (InputManager.SwipeLeft()) {
            RotateCamera(-cameraRotateStepAngle);
        } else if (InputManager.SwipeRight()) {
            RotateCamera(cameraRotateStepAngle);
        }

        desiredPosition = playerMovement.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothness * Time.deltaTime);
        transform.LookAt(playerMovement.transform.position + playerViewOffset);
    }

    public void RotateCamera(float angle)
    {
        offset = Quaternion.Euler(0, angle, 0) * offset;
    }

    
}