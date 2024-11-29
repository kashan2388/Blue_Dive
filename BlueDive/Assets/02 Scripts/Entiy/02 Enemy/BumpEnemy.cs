using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpEnemy : MonoBehaviour
{
    // 플레이어가 몹과 부딪혔을 때 피해를 입히는가?

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = GetComponent<Player>();

        if(player != null)
        {
            // 대상에게 데미지
            // player.Damage();
        }
    }
}
