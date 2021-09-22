using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public void StartProduction() => StartCoroutine("ProducionProcess");
    public void PauseProduction() => StopCoroutine("ProducionProcess");
    public abstract void Produce();

    private IEnumerator ProducionProcess()
    {
        yield return new WaitForSeconds(1f);
        Produce();
    }
    private void Start() => StartProduction();
}
