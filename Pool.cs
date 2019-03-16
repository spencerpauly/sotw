using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool {
    public string tag;
    public GameObject prefab;

    private Queue<GameObject> objects = new Queue<GameObject>();

    public GameObject Get(Vector3? position, Quaternion? rotation) {
        Vector3 pos = position ?? Vector3.zero;
        Quaternion rot = rotation ?? Quaternion.identity;

        if (objects.Count == 0) {
            AddObjects(1);
        }

        GameObject returnObject = objects.Dequeue();
        returnObject.transform.position = pos;
        returnObject.transform.rotation = rot;
        returnObject.SetActive(true);
        return returnObject;
    }

    public void ReturnToPool(GameObject objectToReturn) {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    public void AddObjects(int count) {
        for (int i = 0; i < count; i++) {
            var newObject = GameObject.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            newObject.GetComponent<PooledDeathHandler>().pool = tag;
            objects.Enqueue(newObject);
        }
    }
}
