using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // 기뢰폭
    [SerializeField] public float range;    // 거리
    [SerializeField] public float damage;   // 데미지
    private WaitForSeconds waitingTime = new WaitForSeconds(3.0f);  // 폭발 대기시간

    public override void Attack()
    {
        StartCoroutine(IEBoom());
        // 플레이어가 닿으면?
        // 플레이어가 1m이내일때?

    }

    IEnumerator IEBoom()
    {
        yield return waitingTime;

        if (Distance(transform) <= range)
        {

            // 폭발 이팩트 생성
            // 생성된 폭발 이펙트에 플레이어가 닿을 경우 플레이어에게 데미지

        }

        Destroy(this);
    }

    private float Distance(Transform transform)
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);

        return distance;
    }

    public override void CoolTime()
    {
        throw new System.NotImplementedException();
    }
}
