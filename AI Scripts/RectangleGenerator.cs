using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleGenerator : FormationGenerator 
{
    public float forwardOffset = 4.0f;
    private float zSum = 0;

    public RectangleGenerator(int rowSize) {
        this.rowSize = rowSize;
    }

    public override Position Next() {
        int row = count / rowSize;
        int col = count % rowSize;

        Vector3 pos = Vector3.zero;

        int side = col % 2 == 1 ? 1 : -1;

        pos += (Vector3.right * 0.5f) * (col + 0.5f) * side;
        pos += Vector3.back * row;

        zSum += pos.z;

        //zSum / count
        offset = new Vector3(0, 0, forwardOffset + row);

        count++;

        return new Position(pos, row);
    }
}
