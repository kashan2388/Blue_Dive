using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoom : Bullet
{
    // 폭발하는 발사체
    [SerializeField] float boomRange;  // 폭발 반경

    protected override void Attack()
    {
        // 폭발 애니메이션
        if (Distance() <= boomRange)
        {
            // 일정거리 이내일 때 플레이어에게 피해
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
