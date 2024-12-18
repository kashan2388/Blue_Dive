using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItem
{
    [SerializeField] private string itemName = "HeaItem";
    [SerializeField] private string description = "플레이어의 산소를 회복시킨다. ";
    [SerializeField] private int recoverAmount = 50;

    private bool isUsed = false;
    public void Use()
    {
        if(isUsed) return;

        Player player = Player.Instance;
        if(player != null )
        {
            player.playerStat.RecoverHP(recoverAmount);
            isUsed = true;
            gameObject.SetActive(false);
        }
    }
    public string GetItemName()
    {
        return itemName;
    }
    public string GetDescription()
    {
        return description;
    }
}
