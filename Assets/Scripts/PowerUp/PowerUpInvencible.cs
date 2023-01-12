using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{

    protected override void OnCollect()
    {
        base.OnCollect();
        HideObject();
    }
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.SetInvencible("<INVENCIBLE/>");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetInvencible("");
        
    }
}
