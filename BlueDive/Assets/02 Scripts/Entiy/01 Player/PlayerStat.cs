using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat 
{
    public enum StatType { HP, Stamina, Gravity, JumpForce, Speed }


    private readonly int maxHp = 5;
    private readonly float maxStamina = 50.0f;
    private readonly float maxGravity = 9.8f;
    private readonly float minGravity = -9.8f;
    // private readonly float jumpForce = 2f;
    private readonly float maxSpeed = 5f;
    private readonly float maxHookMoveSpeed = 4f;

    private int currentHP;
    private float currentStamina;
    private float currentGravity;
    // private float currentJumpForce;
    private float currentSpeed;
    private float currentHookMoveSpeed;


    public PlayerStat() => InitializeStat();

    public void InitializeStat()
    {
        currentHP = maxHp;
        currentStamina = maxStamina;
        currentGravity = 1f;
        // currentJumpForce = jumpForce;
        currentSpeed = maxSpeed;
        currentHookMoveSpeed = maxHookMoveSpeed;
    }

    public int CurrentHP => currentHP;
    public float CurrentStamina => currentStamina;
    public float CurrentGravity => currentGravity;

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
    #endregion

    #region 스태미나 스탯 관련 

    public void ConsumeStamina(float amount)
    {
        currentStamina = Mathf.Max(CurrentStamina - amount, 0);

    }
    public void RecoverStamina(float amount)
    {
        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
    }

    #endregion

    // 중력 전환
    public void ToggleGravity()
    {
        currentGravity = currentGravity == maxGravity ? minGravity : maxGravity; 
    }

    public void SetGravity(float value)
    {
        currentGravity = value;
    }

}
