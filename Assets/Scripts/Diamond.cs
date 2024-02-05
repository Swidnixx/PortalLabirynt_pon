using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup 
{
    protected override void Pick()
    {
        base.Pick(); // wywo³anie wersji bazowej metody

        GameManager.Instance.AddDiamond();
    }
}
