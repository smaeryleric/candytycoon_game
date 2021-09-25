using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    private Grid grid;
    private void Start()
    {
        grid = GetComponent<Grid>();
        Building newBuilding = new TownHall(new Vector2Int(0, 0));
    }
}
