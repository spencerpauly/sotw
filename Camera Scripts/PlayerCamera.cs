using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCamera : MonoBehaviour
{
    public PlayerMovement playerMovement;

    [Range(0, 90)]
    public float cameraAngle;
    public float CameraAngle { set { cameraAngle = value; } }
    [Range(2, 40)]
    public float cameraDistance;
    public float CameraDistance { set { cameraDistance = value; } }
    [Range(0, 20)]
    public float cameraOffset;
    [Range(0, 180)]
    public int cameraRotateStepAngle;
    //
    public float CameraRotateStepAngle {  set {
        if (value == 0) { cameraRotateStepAngle = 45; } else { cameraRotateStepAngle = 90; }
    } }
    //
    [Range(0, 20)]
    public float cameraSmoothness;

    public Vector3 GetLookDirection() {
        return VectorPlus.DegreeToVector(transform.eulerAngles.y);
    }

}
