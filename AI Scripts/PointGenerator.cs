using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : FormationGenerator 
{
    public float forwardOffset = -4.0f;

    public override Position Next() {
        offset = new Vector3(0.0f, 0.0f, forwardOffset);
        Vector3 pos = Vector3.zero;
        return new Position(pos, 0);
    }
}
