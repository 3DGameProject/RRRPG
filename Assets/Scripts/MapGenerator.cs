using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float tileScale = 20f;
    public TilePool tilePool;
    public Transform player;
    public int renderDistance = 100;
    public float fixedYPosition = 0f; // 고정된 y 좌표 값
    public float fixedYScale = 1f; // 고정된 y 스케일 값
    public int tileSpacing = 2; // 타일 간격을 추가로 설정

    private HashSet<Vector3> activeTiles = new HashSet<Vector3>();

    private void Start()
    {
        GenerateInitialTiles();
    }

    private void Update()
    {
        GenerateTilesAhead();
    }

    private void GenerateInitialTiles()
    {
        for (int x = -renderDistance; x < renderDistance; x += tileSpacing) // 간격을 추가하여 타일 생성
        {
            GenerateTileAt(new Vector3(x * tileScale, 0, 0));
        }
    }

    private void GenerateTilesAhead()
    {
        int playerX = Mathf.FloorToInt(player.position.x / tileScale);
        for (int x = playerX; x > playerX - renderDistance; x -= tileSpacing) // 간격을 추가하여 타일 생성
        {
            GenerateTileAt(new Vector3(x * tileScale, 0, 0));
        }
    }

    private void GenerateTileAt(Vector3 position)
    {
        if (!activeTiles.Contains(position))
        {
            Vector3 tilePosition = new Vector3(position.x, fixedYPosition, position.z); // y 좌표를 고정된 값으로 설정
            GameObject tile = tilePool.GetTile(tilePosition);
            tile.transform.localScale = new Vector3(tileScale, fixedYScale, tileScale); // y 스케일을 고정된 값으로 설정
            activeTiles.Add(position);
        }
    }
}
