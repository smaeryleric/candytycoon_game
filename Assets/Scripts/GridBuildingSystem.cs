using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem Instance;

    [SerializeField] private GridLayout _gridLayout;
    [SerializeField] private Tilemap _mainTilemap;
    [SerializeField] private Tilemap _tempTilemap;
    [SerializeField] private Tile _highlightedTile;

    [SerializeField] private GameObject ObjPrefab;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int currentCell = _mainTilemap.WorldToCell(mousePos);
            _mainTilemap.SetTile(currentCell, _highlightedTile);

            Debug.Log(currentCell);
            Vector2 cellPos = _mainTilemap.CellToWorld(currentCell);
            
            Instantiate(ObjPrefab, new Vector2(cellPos.x, cellPos.y), Quaternion.identity);
        }
    }
}
