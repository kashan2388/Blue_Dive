using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Gardeneel : Enemy
{
    // ���� ������
    [SerializeField] public float damage = 5.0f;   // ������
    [SerializeField] public float coolTime = 0.7f; // ���� ��Ÿ��

    public override void Attack()
    {
        // �÷��̾�� ���� �ִϸ��̼� �� ����
        if(target != null)
        {
            // ������
            // Player.Instance.Damage(damage);
        }
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
