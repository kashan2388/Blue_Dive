using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SeaWeed : MonoBehaviour
{
    // ������ ����
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            // �÷��̾� �ӵ� ����
        }
    }
}
