using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bearfish : Enemy
{
    // 큰 이빨 곰치
    [SerializeField] public WaitForSeconds warningTime = new WaitForSeconds(1.0f);  // 경고 시간
    [SerializeField] public GameObject warningBlock;    // 경고 블록

    public override void Attack()
    {
        // 플레이어에게 경고 후 애니메이션 및 피해
        Warning();
    }

    IEnumerator Warning()
    {
        warningBlock.SetActive(true);

        yield return warningTime;

        warningBlock.SetActive(false);

        if (target != null)
        {
            Damage(damage);
        }
    }
}
