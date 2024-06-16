using UnityEngine;
using System.Collections.Generic;

public class MapGenerater : MonoBehaviour
{
    public GameObject mapPrefab;
    public int poolSize = 10;

    private Queue<GameObject> mapPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject map = Instantiate(mapPrefab);
            map.SetActive(false); 
            mapPool.Enqueue(map); 
        }
    }

    public GameObject GetBulletFromPool()
    {
        if (mapPool.Count > 0)
        {
            GameObject bullet = mapPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(mapPrefab);
            return bullet;
        }
    }

    public void ReturnBulletToPool(GameObject map)
    {
        map.SetActive(false); 
        mapPool.Enqueue(map); 
    }
}
