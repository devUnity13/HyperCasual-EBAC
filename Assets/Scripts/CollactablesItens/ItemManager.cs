using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI uiTextCoins;
    private void Start() 
    {
        Reset();
    }

    public void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = "X: " + coins.ToString();
        //InGameUiManager.UpdateTextCoins("X: " + coins.value.ToString());
    }
}
