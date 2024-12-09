using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    // �Ϲ� �߻�ü
    protected Vector3 target;
    protected float damage = 0;             // ���ط�
    protected float speed = 0;              // �߻�ü �ӵ�
    protected float range = 0;              // ��Ÿ�
    protected bool penetrating = false;     // �� ���뿩��

    protected Vector3 startVector;
    protected Vector3 goal;
    protected void Start()
    {
        startVector = transform.parent.transform.position;
    }
    protected virtual void Update()
    {
        // �ڽ��� ��ġ���� ������ ������ �ӵ��� �̵�
        transform.position = Vector2.MoveTowards(startVector, goal, speed);

        // ��ǥ��ġ ���� �� �Ҹ�
        if(transform.position == target)
        {
            Destroy(gameObject);
        }
    }

    public void Information(Vector3 target, float damage, float speed, float range, bool penetrating)
    {
        this.target = target;
        this.damage = damage;
        this.speed = speed;
        this.range = range;
        this.penetrating = penetrating;
        
        goal = (startVector - target).normalized * range;
    }

    // ���뿩�ο� ���� ������� �Ҹ�
    protected virtual void OnTriggerEnter2D(Collider2D collision)
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
        Damage(damage);
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        // Player.Instance.Damage(damage);
    }
}
