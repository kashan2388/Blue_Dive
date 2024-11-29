using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Enemy
{
    // ���Ÿ� ���� ����
    [SerializeField] public float attack;          // ������
    [SerializeField] public float coolTime;        // ���� ��Ÿ��
    [SerializeField] public GameObject projectile; // �߻�ü ������


    public override void Attack()
    {
        //����ü ���� �� �÷��̾�� �߻�
        GameObject projectiles = Instantiate(projectile, transform);
        projectiles.transform.SetParent(transform);
        projectiles.GetComponent<Bullet>().Shot(target);
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
