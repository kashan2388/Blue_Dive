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
        // �÷��̾�� ���� �ִϸ��̼� �� ����
        throw new System.NotImplementedException();
    }
}
