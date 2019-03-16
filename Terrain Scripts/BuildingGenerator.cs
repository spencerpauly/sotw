using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {
    public GeneratorSettings settings;

    void Start() {
        float[,] buildingMap = Noise.GenerateNoiseMap(settings);

        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);

        for (int x = 0; x < settings.mapWidth; x++) {
            for (int y = 0; y < settings.mapHeight; y++) {
                CreateCube(x, y, settings.animationCurve.Evaluate(buildingMap[x, y]), floor);
            }
        }
        
        
    }

    private void CreateCube(int x, int y, float height, GameObject parent) {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(x, 0.5f + height * 0.5f, y);
        cube.transform.localScale += new Vector3(settings.scaleMultiplier, height * 6, settings.scaleMultiplier);
        cube.transform.parent = parent.transform;

        //Renderer renderer = cube.GetComponent<Renderer>();
        //renderer.material.color = Color.white;
    }
}