using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat 
{
    public enum StatType { HP, Stamina, Gravity, JumpForce, Speed }


    private readonly int maxHp = 100;
    private readonly float maxStamina = 50.0f;
    private readonly float maxGravity = 9.8f;
    private readonly float minGravity = -9.8f;
    // private readonly float jumpForce = 2f;
    private readonly float maxSpeed = 5f;
    private readonly float maxHookMoveSpeed = 15f;

    private int maxHP;
    private int currentHP;
    private float currentStamina;
    private float currentGravity;
    public float defaultGravity = 1f;
    // private float currentJumpForce;
    private float currentSpeed;
    private float currentHookMoveSpeed;


    public PlayerStat() => InitializeStat();

    public void InitializeStat()
    {
        currentHP = maxHp;
        currentStamina = maxStamina;
        currentGravity = defaultGravity;
        // currentJumpForce = jumpForce;
        currentSpeed = maxSpeed;
        currentHookMoveSpeed = maxHookMoveSpeed;
    }

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;
    public float CurrentStamina => currentStamina;
    public float CurrentGravity
    {
        get => currentGravity;
        set => currentGravity = Mathf.Clamp(value, minGravity, maxGravity);
    }

    // public float CurrentJumpForce => currentJumpForce;
    public float CurrentSpeed => currentSpeed;
    public float CurrentHookMoveSpeed => currentHookMoveSpeed;


    #region HP 스탯 관련 
    public void TakeDamage(int damage)
    {
        Mathf.Max(currentHP - damage, 0);
    }

    public void RecoverHP(int amount)
    {
        Mathf.Min(currentHP + amount, maxHp);
    }
    public void ConsumeHP(int amount)
    {
        currentHP = Mathf.Max(currentHP - amount, 0);

    }

    #endregion

    // 중력 전환
    public void ToggleGravity()
    {
        currentGravity = currentGravity == maxGravity ? minGravity : maxGravity; 
    }

}
