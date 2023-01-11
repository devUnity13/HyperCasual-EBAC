using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollactableBase
{
    public float duration = 1f;
    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }

    protected void StartPowerUp()
    {
        Debug.Log("Nice PowerUp!");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected void EndPowerUp()
    {
        Debug.Log("Acabou PowerUp!");
    }
}
