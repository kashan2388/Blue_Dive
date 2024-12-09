using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Enemy
{
    // ���Ÿ� ���� ����
    [SerializeField] public GameObject projectile;      // �߻�ü ������
    [SerializeField] public float speed = 1.0f;         // �߻�ü �ӵ�
    [SerializeField] public float range = 1.0f;         // ���� ��Ÿ�
    [SerializeField] public bool penetrating = false;   // �� ���뿩��


    public override void Attack()
    {
        //����ü ���� �� �÷��̾�� �߻�
        GameObject projectiles = Instantiate(projectile, transform);
        projectiles.transform.SetParent(transform);
        projectiles.GetComponent<Bullet>().Information(target.position, damage, speed, range, penetrating);
    }
}
