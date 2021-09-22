using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStation : Building
{
    public override void Produce()
    {
        Debug.Log("Producing kilowatt");
    }
}
