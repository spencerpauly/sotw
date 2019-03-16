using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorPlus
{
    public static Vector3 DegreeToVector(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a));
    }

    public static float VectorToDegree(Vector3 input) {
        Vector2 input2d = new Vector2(input.x, input.z);
        float differenceAngle = Vector2.SignedAngle(Vector2.right, input2d);
        return differenceAngle;
    }

    public static Vector3 ToVector3(this Vector2 vec) {
        return new Vector3(vec.x, 0, vec.y);
    }

    public static Vector2 ToVector2(this Vector3 vec) {
        return new Vector2(vec.x, vec.z);
    }

    public static bool IsAt(this Vector3 v1, Vector3 v2, float error = 0.3f) {
        return Vector2.Distance(v1.ToVector2(), v2.ToVector2()) < error;
    }

}
