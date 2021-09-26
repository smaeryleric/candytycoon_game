using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    #region Production
    private void StartProduction() => StartCoroutine("ProducionProcess");
    private void PauseProduction() => StopCoroutine("ProducionProcess");
    private void Produce()
    {
    }
    private IEnumerator ProducionProcess()
    {
        yield return new WaitForSeconds(1f);
        Produce();
    }
    #endregion
    private void Start() => StartProduction();

    public Vector2Int GetCell()
    {
        return GridBuildingSystem.Instance.GetCellPosition(transform.position);
    }

    public Vector3Int[] FilledCells
    {
        get
        {
            List<Vector3Int> cells = new List<Vector3Int>();

            for (int i = -1; i <= 1; ++i)
                for (int j = -1; j <= 1; ++j)
                    cells.Add(new Vector3Int(GetCell().x + j, GetCell().y + i, 0));

            return cells.ToArray();
        }
    }
}
