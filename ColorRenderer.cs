using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Renderer))]
public class ColorRenderer : MonoBehaviour
{
    public Color color;

    private Renderer rend;

    // Start is called before the first frame update
    void Start() {
        rend = GetComponent<Renderer>();
        rend.material.color = color;
    }

    public void SetColor(float r, float g, float b) {
        rend.material.color = new Color(r, g, b);
    }
}
