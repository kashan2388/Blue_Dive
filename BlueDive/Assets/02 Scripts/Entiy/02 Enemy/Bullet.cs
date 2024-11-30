using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    // �Ϲ� �߻�ü
    private float damage = 0;          // ���ط�
    private float speed = 0;           // �߻�ü �ӵ�
    private bool penetrating = false;  // �� ���뿩��

    private Transform target;

    protected virtual void Update()
    {
        // �ڽ��� ��ġ���� ������ ������ �ӵ��� �̵�
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        // ��ǥ��ġ ���� �� �Ҹ�
        if(transform.position == target.position)
        {
            Destroy(gameObject);
        }
    }

    public void Shot(Transform target, float damage, float speed, bool penetrating)
    {
        this.target = target;
        this.damage = damage;
        this.speed = speed;
        this.penetrating = penetrating;
    }

    // ���뿩�ο� ���� ������� �Ҹ�
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // �÷��̾�� ���� �� �Ҹ�
            Attack();
        }
        else if (!penetrating)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �÷��̾�� ���� �ִ� ���, ���� �Ҹ�
    /// </summary>
    protected virtual void Attack()
    {
        // Player.Instance.Damage(damage);
        Destroy(gameObject);
    }
}
