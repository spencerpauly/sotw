using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    [SerializeField]
    public List<Pool> pools = new List<Pool>();

    private Dictionary<string, Pool> poolDictionary;

    private void Awake() {
        Instance = this;

        poolDictionary = new Dictionary<string, Pool>();

        foreach (Pool pool in pools) {
            poolDictionary.Add(pool.tag, pool);
        }
    }

    public GameObject Get(string tag, Vector3? position = null, Quaternion? rotation = null) {
        
        //if (!poolDictionary.ContainsKey(tag)) {
        //    Debug.LogWarning("Pool with tag " + tag + " not found while grabbing from pool.");
        //    return null;
        //}

        return poolDictionary[tag].Get(position, rotation);
    }

    public void ReturnToPool (string tag, GameObject objectToReturn) {
        if (poolDictionary[tag] == null) {
            Debug.LogWarning("Pool with tag " + tag + " not found while returning to pool.");
        } else {
            poolDictionary[tag].ReturnToPool(objectToReturn);
        }
    }
}
