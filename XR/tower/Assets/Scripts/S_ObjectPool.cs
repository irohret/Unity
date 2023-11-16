using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjectPool
{
    private List<GameObject> pool;
    private GameObject prefab;

    public S_ObjectPool(GameObject prefab, int initialSize){
        this.prefab = prefab;
        pool = new List<GameObject>();

        for (int i = 0; i < initialSize; i++){
            GameObject obj = Object.Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject(){
        foreach (GameObject obj in pool){
            if (!obj.activeSelf) {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Object.Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }
}
