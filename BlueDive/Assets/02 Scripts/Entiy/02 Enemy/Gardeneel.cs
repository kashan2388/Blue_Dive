using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardeneel : Enemy
{
    // 성난 가든일
    public override void Attack()
    {
        // 플레이어에게 공격 애니메이션 및 피해
        if(target != null)
        {
            Damage(damage);
        }
    }
}
