using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Enemy
{
    // ���Ÿ� ���� ����
    [SerializeField] public float damage = 1.0f;   // �߻�ü ������
    [SerializeField] public float speed = 1.0f;    // �߻�ü �ӵ�
    [SerializeField] public float coolTime = 0.5f; // ���� ��Ÿ��
    [SerializeField] public bool penetrating = false; // �� ���뿩��
    [SerializeField] public GameObject projectile; // �߻�ü ������


    public override void Attack()
    {
        //����ü ���� �� �÷��̾�� �߻�
        GameObject projectiles = Instantiate(projectile, transform);
        projectiles.transform.SetParent(transform);
        projectiles.GetComponent<Bullet>().Shot(target, damage, speed, penetrating);
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
