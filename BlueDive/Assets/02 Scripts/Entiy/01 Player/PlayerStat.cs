using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat 
{
    public enum StatType { HP, Stamina, Gravity, JumpForce, Speed }


    private readonly int maxHp = 5;
    private readonly int maxStamina = 30;
    private readonly float maxGravity = 9.8f;
    private readonly float minGravity = -9.8f;
    private readonly float jumpForce = 2f;
    private readonly float maxSpeed = 5f;

    private int currentHP;
    private int currentStamina;
    private float currentGravity;
    private float currentJumpForce;
    private float currentSpeed;


    public PlayerStat()
    {
        InitializeStat();
    }

    public void InitializeStat()
    {
        currentHP = maxHp;
        currentStamina = maxStamina;
        currentGravity = maxGravity;
        currentJumpForce = jumpForce;
        currentSpeed = maxSpeed;
    }

    public int CurrentHP => currentHP;
    public int CurrentStamina => currentStamina;
    public float CurrentGravity => currentGravity;

    public float CurrentJumpForce => currentJumpForce;
    public float CurrentSpeed => currentSpeed;


    #region HP ���� ���� 
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) currentHP = 0;
    }

    public void RecoverHP(int amount)
    {
        currentHP += amount;
        if(currentHP >= maxHp) currentHP = maxHp;
    }
    #endregion

    #region ���¹̳� ���� ���� 

    public void ConsumeStamina(int amount)
    {
        currentStamina = Mathf.Max(CurrentStamina - amount, 0);

    }
    public void RecoverStamina(int amount)
    {
        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
    }


    #endregion

    // �߷� ��ȯ
    public void ToggleGravity()
    {
        currentGravity = currentGravity == maxGravity ? minGravity : maxGravity; 
    }

}
