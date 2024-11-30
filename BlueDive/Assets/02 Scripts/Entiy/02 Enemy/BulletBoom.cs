using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoom : Bullet
{
    // �����ϴ� �߻�ü
    [SerializeField] float boomRange;  // ���� �ݰ�

    protected override void Attack()
    {
        // ���� �ִϸ��̼�
        if (Distance() <= boomRange)
        {
            // �����Ÿ� �̳��� �� �÷��̾�� ����
            // Player.Instance.Damaga(attack);
        }
    }

    public void OnDestroy()
    {
        Destroy(this);
    }

    private float Distance()
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);

        return distance;
    }

}
