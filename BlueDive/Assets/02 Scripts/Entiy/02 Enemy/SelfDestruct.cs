using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // 기뢰폭
    [SerializeField] public float range = 3.0f;    // 거리
    [SerializeField] public float damage = 15.0f;  // 데미지
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
            // 일정거리 이내일 때 플레이어에게 피해
            // Player.Instance.Damaga(attack);
        }

        Destroy(this);
    }

    private float Distance()
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);

        return distance;
    }

    public override void CoolTime()
    {
        throw new System.NotImplementedException();
    }
}
