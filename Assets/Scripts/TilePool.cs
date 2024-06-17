using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    public GameObject Cube;
    public int poolSize = 100;

    private Queue<GameObject> pool;

    void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject tile = Instantiate(Cube);
            tile.SetActive(false);
            pool.Enqueue(tile);
        }
    }

    public GameObject GetTile(Vector3 position)
    {
        if (pool.Count == 0)
        {
            GameObject tile = Instantiate(Cube);
            tile.SetActive(false);
            pool.Enqueue(tile);
        }

        GameObject obj = pool.Dequeue();
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        pool.Enqueue(tile);
    }
}
