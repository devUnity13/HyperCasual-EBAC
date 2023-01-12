using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpHeigth : PowerUpBase
{
    public float heigth;
    public float animationDuration;
    public Ease ease = Ease.OutBounce;

    protected override void OnCollect()
    {
        base.OnCollect();
        HideObject();
    }

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.SetHeigth("<Flying/>", heigth, duration, animationDuration, ease);
        Invoke(nameof(EndPowerUp), duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetHeight("", animationDuration, ease);
    }
}
