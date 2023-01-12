using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    public float upScale = 10;

    protected override void OnCollect()
    {
        base.OnCollect();
        HideObject();
    }

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.CollectAllCoins(upScale);
        Invoke(nameof(EndPowerUp), duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetCollectAllCoins();
    }
}
