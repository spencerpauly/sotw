using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FormationGenerator 
{
    public Vector3 offset;
    public int count = 0;
    public int rowSize = 0;

    public abstract Position Next();
}
