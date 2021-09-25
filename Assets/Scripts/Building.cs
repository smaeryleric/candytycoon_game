using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    #region Production
    private void StartProduction() => StartCoroutine("ProducionProcess");
    private void PauseProduction() => StopCoroutine("ProducionProcess");
    public abstract void Produce();
    private IEnumerator ProducionProcess()
    {
        yield return new WaitForSeconds(1f);
        Produce();
    }
    #endregion

    #region World Controls
    private Vector2Int gridPosition;
    #endregion

    private void Start() => StartProduction();

    public Building(Vector2Int gridPosition)
    {
        this.gridPosition = gridPosition;
    }
}
