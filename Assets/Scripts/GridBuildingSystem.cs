using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem Instance;

    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tile occupiedTile;
    [SerializeField] private GameObject buildingPrefab;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Spawn();
    }

    public Vector2Int GetCellPosition(Vector2 worldPosition)
    {
        return (Vector2Int)grid.WorldToCell(worldPosition);
    }
    private void Spawn()
    {
        Vector2Int cellPos = new Vector2Int(3, 4);
        Vector2 worldPos = grid.CellToWorld((Vector3Int)cellPos);

        Building building = Instantiate(buildingPrefab, worldPos, Quaternion.identity).GetComponent<Building>();

        for (int i = 0; i < building.FilledCells.Length; i++)
        {
            mainTilemap.SetTile(building.FilledCells[i], occupiedTile);
        }
    }
}
