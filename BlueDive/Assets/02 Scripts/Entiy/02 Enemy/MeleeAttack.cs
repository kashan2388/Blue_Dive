using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Stat()
    {
        attackRange = 0;
        attackCoolTime = float.MaxValue;
    }

    public override void Attack()
    {
        // 플레이어에게 공격 애니메이션 및 피해
        throw new System.NotImplementedException();
    }
}
