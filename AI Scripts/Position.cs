using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public Vector3 location;
    public int priority;

    public Position(Vector3 location, int priority) {
        this.location = location;
    }
}
