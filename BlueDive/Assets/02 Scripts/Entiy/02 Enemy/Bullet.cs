using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] public float damage = 0;          // 피해량
    [SerializeField] public float speed = 0;           // 투사체 속도
    [SerializeField] public bool penetrating = false;  // 벽 관통여부

    private Transform target;

    private void Update()
    {
        // 자신의 위치에서 대상까지 일정한 속도로 이동
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        // 목표위치 도달 시 소멸
        if(transform.position == target.position)
        {
            Destroy(gameObject);
        }
    }

    public void Shot(Transform target)
    {
        this.target = target;
    }

    // 관통여부에 따라 닿을경우 소멸
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // 플레이어에게 피해 후 소멸
            Attack();
            Destroy(gameObject);
        }
        else if (!penetrating)
        {
            if (collision.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 플레이어에게 피해 주는 방법
    /// </summary>
    protected abstract void Attack();
}
