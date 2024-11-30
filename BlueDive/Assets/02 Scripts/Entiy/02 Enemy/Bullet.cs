using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    // 일반 발사체
    private float damage = 0;          // 피해량
    private float speed = 0;           // 발사체 속도
    private bool penetrating = false;  // 벽 관통여부

    private Transform target;

    protected virtual void Update()
    {
        // 자신의 위치에서 대상까지 일정한 속도로 이동
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        // 목표위치 도달 시 소멸
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

    // 관통여부에 따라 닿을경우 소멸
    protected void OnTriggerEnter2D(Collider2D collision)
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
        // Player.Instance.Damage(damage);
        Destroy(gameObject);
    }
}
