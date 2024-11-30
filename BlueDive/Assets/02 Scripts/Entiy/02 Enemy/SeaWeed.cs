using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SeaWeed : MonoBehaviour
{
    // 끈끈이 해초

    [SerializeField] public float slowLate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            // 플레이어 속도 감소
            // player.Speed(slowLate);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            // 플레이어 속도 복구
            // player.Speed(1);
        }
    }
}
