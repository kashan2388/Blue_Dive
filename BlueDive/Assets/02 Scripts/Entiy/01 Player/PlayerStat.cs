using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat 
{
    private readonly int maxHp = 100;
    private readonly float maxGravity = 9.8f;
    private readonly float minGravity = -9.8f;
    private readonly float maxSpeed = 5f;
    private readonly float maxHookMoveSpeed = 15f;
    private readonly float defaultGravity = 0.1f;

    private int currentHP;
    private float currentGravity;
    private float currentSpeed;
    private float currentHookMoveSpeed;
    
    public PlayerStat() => InitializeStat();

    public void InitializeStat()
    {
        currentHP = maxHp;
        currentGravity = defaultGravity;
        currentSpeed = maxSpeed;
        currentHookMoveSpeed = maxHookMoveSpeed;
    }

    public int MaxHP => maxHp;
    public int CurrentHP => currentHP;
    public float DefaultGravity => defaultGravity;
    public float CurrentGravity
    {
        get => currentGravity;
        set => currentGravity = Mathf.Clamp(value, minGravity, maxGravity);
    }

    public float CurrentSpeed
    {
        get => currentSpeed;
        set => currentSpeed = Mathf.Clamp(value, 0f, maxSpeed);
    }
    public float CurrentHookMoveSpeed => currentHookMoveSpeed;


    #region HP ½ºÅÈ °ü·Ã 
    public void TakeDamage(int damage)
    {
        currentHP = Mathf.Max(currentHP - damage, 0);
    }

    public void RecoverHP(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHp);
    }
    public void ConsumeHP(int amount)
    {
        currentHP = Mathf.Max(currentHP - amount, 0);
    }

    #endregion

}
