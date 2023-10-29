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
        particleSystem.Stop();
    }

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.CollectAllCoins("<Greedy/>", upScale);
        Invoke(nameof(EndPowerUp), duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetCollectAllCoins();
    }
}
