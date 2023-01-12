using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    public float amountSpeed = 10;

    protected override void OnCollect()
    {
        base.OnCollect();
        HideObject();
    }
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.IncreaseSpeed("<SPEEDUP/>", amountSpeed);
        Invoke(nameof(EndPowerUp), duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        if (PlayerController.instance.invencible)
        {
            PlayerController.instance.SetInvencible("<INVENCIBLE/>");
        }
        else
        {
            PlayerController.instance.ResetSpeed("");
        }
        
    }
}
