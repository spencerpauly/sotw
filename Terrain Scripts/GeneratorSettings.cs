using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneratorSettings {
    public int mapWidth;
    public int mapHeight;
    public int seed;
    public float scale;
    public int octaves;
    public float persistance;
    public float lacunarity;
    public Vector2 offset;
    public NormalizeMode normalizeMode;
    public AnimationCurve animationCurve;
    public float scaleMultiplier;
}

public enum NormalizeMode {
    Local,
    Global
};
