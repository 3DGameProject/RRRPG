using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;
    public int poolSize = 10;
    public GameObject player;

    private Queue<GameObject> mapPool = new Queue<GameObject>();
    private Vector3 currentPosition; // ���� ��ġ�� ������ ����

    void Start()
    {
        currentPosition = player.transform.position; // ���� �� ���� ��ġ ����

        for (int i = 0; i < poolSize; i++)
        {
            GameObject map = Instantiate(mapPrefab, GetSpawnPosition(), Quaternion.identity);
            map.SetActive(false);
            mapPool.Enqueue(map);
        }
    }

    public GameObject GetMapFromSPool()
    {
        if (mapPool.Count > 0)
        {
            GameObject map = mapPool.Dequeue();
            map.SetActive(true);
            return map;
        }
        else
        {
            GameObject map = Instantiate(mapPrefab, GetSpawnPosition(), Quaternion.identity);
            return map;
        }
    }

    public void ReturnMapToPool(GameObject map)
    {
        map.SetActive(false);
        mapPool.Enqueue(map);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = currentPosition + new Vector3(-40f, 0f, 0f);
        return spawnPosition;
    }

    void Update()
    {
        currentPosition = player.transform.position;
    }
}
