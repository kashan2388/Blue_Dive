using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SeaWeed : MonoBehaviour
{
    // ������ ����

    [SerializeField] public float slowLate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            // �÷��̾� �ӵ� ����
            // player.Speed(slowLate);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            // �÷��̾� �ӵ� ����
            // player.Speed(1);
        }
    }
}
