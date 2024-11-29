using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bearfish : Enemy
{
    // 큰 이빨 곰치
    [SerializeField] public float attack;          // 데미지
    [SerializeField] public float coolTime;        // 공격 쿨타임
    public override void Attack()
    {
        // 플레이어에게 공격 애니메이션 및 피해
        throw new System.NotImplementedException();
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
