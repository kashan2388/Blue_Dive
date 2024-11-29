using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SeaWeed : MonoBehaviour
{
    // 끈끈이 해초
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            // 플레이어 속도 감소
        }
    }
}
