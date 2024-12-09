using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletBoom : Bullet
{
    // �����ϴ� �߻�ü
    [SerializeField] float boomRange;  // ���� �ݰ�

    protected override void Update()
    {
        // �ڽ��� ��ġ���� ������ ������ �ӵ��� �̵�
        transform.position = Vector2.MoveTowards(startVector, goal, speed);


        // ��ǥ��ġ ���� �� �Ҹ�
        if (transform.position == target)
        {
            Attack();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // �÷��̾�� ���� �� �Ҹ�
            Attack();
        }
        else if (!penetrating)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        // ���� �ִϸ��̼� �߰�
        if (Distance() <= boomRange)
        {
            Damage(damage);
        }
    }

    // �ִϸ��̼� ���� �ֱ�
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
