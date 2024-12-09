using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    // 일반 발사체
    protected Vector3 target;
    protected float damage = 0;             // 피해량
    protected float speed = 0;              // 발사체 속도
    protected float range = 0;              // 사거리
    protected bool penetrating = false;     // 벽 관통여부

    protected Vector3 startVector;
    protected Vector3 goal;
    protected void Start()
    {
        startVector = transform.parent.transform.position;
    }
    protected virtual void Update()
    {
        // 자신의 위치에서 대상까지 일정한 속도로 이동
        transform.position = Vector2.MoveTowards(startVector, goal, speed);

        // 목표위치 도달 시 소멸
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

    // 관통여부에 따라 닿을경우 소멸
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // 플레이어에게 피해 후 소멸
            Attack();
        }
        else if (!penetrating)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 플레이어에게 피해 주는 방법, 이후 소멸
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
