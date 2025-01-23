using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // 기뢰폭
    [SerializeField] public float range = 3.0f;    // 거리
    private WaitForSeconds waitingTime = new WaitForSeconds(3.0f);  // 폭발 대기시간

    public override void Attack()
    {
        StartCoroutine(IEBoom());
    }

    IEnumerator IEBoom()
    {
        yield return waitingTime;

        // 폭발 이팩트 생성

        if (Distance() <= range)
        {
            Damage(damage);
        }

        Destroy(gameObject);
    }

    private float Distance()
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);
        // 플레이어 추가 후 확인해볼것

        return distance;
    }
}
