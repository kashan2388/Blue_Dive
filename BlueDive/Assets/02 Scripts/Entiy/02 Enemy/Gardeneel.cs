using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Gardeneel : Enemy
{
    // 성난 가든일
    [SerializeField] public float damage = 5.0f;   // 데미지
    [SerializeField] public float coolTime = 0.7f; // 공격 쿨타임

    public override void Attack()
    {
        // 플레이어에게 공격 애니메이션 및 피해
        if(target != null)
        {
            // 데미지
            // Player.Instance.Damage(damage);
        }
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
