using System.Collections.Generic;
using UnityEngine;

public class MapGenerater : MonoBehaviour
{
    public GameObject mapPrefab;
    public int poolSize = 10;

    private Queue<GameObject> mapPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject map = Instantiate(mapPrefab, GetSpawnPosition(), Quaternion.identity);
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
            GameObject bullet = Instantiate(mapPrefab, GetSpawnPosition(), Quaternion.identity);
            return bullet;
        }
    }

    public void ReturnBulletToPool(GameObject map)
    {
        map.SetActive(false);
        mapPool.Enqueue(map);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 currentPosition = transform.position;
        Vector3 spawnPosition = currentPosition + new Vector3(-40f, 0f, 0f);
        return spawnPosition;
    }
}
