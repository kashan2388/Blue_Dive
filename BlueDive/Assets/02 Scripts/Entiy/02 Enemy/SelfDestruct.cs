using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // 폭발 대기시간
    WaitForSeconds waitingTime = new WaitForSeconds(0.0f);

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Stat()
    {
        attackRange = 0;
        attackCoolTime = float.MaxValue;
    }

    public override void Attack()
    {
        StartCoroutine(IEBoom());

        Destroy(this);
    }

    IEnumerator IEBoom()
    {
        yield return waitingTime;

        if(Vector2.Distance(target.position, transform.position) <= attackRange)
        {
            // 플레이어에게 데미지
        }
    }
}
