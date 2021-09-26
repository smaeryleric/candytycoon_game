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

    private Building _selectedBuilding;
    public Building SelectedBuilding
    {
        get
        {
            return _selectedBuilding;
        }
        set
        {
            _selectedBuilding = value;
        }
    }
    
    private void Awake() =>
        Instance = this;
    private void Start()
    {
        Spawn(new Vector3Int(0,0,0));
        Spawn(new Vector3Int(5,4,0));
        Spawn(new Vector3Int(3,-5,0));
    }
    public Vector3Int GetCellPosition(Vector3 worldPosition)
    {
        return grid.WorldToCell(worldPosition);
    }
    private void Spawn(Vector3Int cellPos)
    {
        Vector3 worldPos = grid.GetCellCenterLocal(cellPos);

        Building building = Instantiate(buildingPrefab, worldPos, Quaternion.identity).GetComponent<Building>();
        building.transform.position = grid.CellToWorld(building.GetCell());

        for (int i = 0; i < building.FilledCells.Length; i++)
        {
            mainTilemap.SetTile(building.FilledCells[i], occupiedTile);
        }
        mainTilemap.SetTile(building.GetCell(), occupiedTile);
    }
}
