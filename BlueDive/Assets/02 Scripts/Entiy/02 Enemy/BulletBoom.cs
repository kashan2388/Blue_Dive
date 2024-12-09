using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletBoom : Bullet
{
    // 폭발하는 발사체
    [SerializeField] float boomRange;  // 폭발 반경

    protected override void Update()
    {
        // 자신의 위치에서 대상까지 일정한 속도로 이동
        transform.position = Vector2.MoveTowards(startVector, goal, speed);


        // 목표위치 도달 시 소멸
        if (transform.position == target)
        {
            Attack();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // 플레이어에게 피해 후 소멸
            Attack();
        }
        else if (!penetrating)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        // 폭발 애니메이션 추가
        if (Distance() <= boomRange)
        {
            Damage(damage);
        }
    }

    // 애니메이션 끝에 넣기
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
