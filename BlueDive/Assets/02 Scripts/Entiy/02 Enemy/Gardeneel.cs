using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Gardeneel : Enemy
{
    // ���� ������
    [SerializeField] public float attack;          // ������
    [SerializeField] public float coolTime;        // ���� ��Ÿ��

    public override void Attack()
    {
        // �÷��̾�� ���� �ִϸ��̼� �� ����
        throw new System.NotImplementedException();
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
