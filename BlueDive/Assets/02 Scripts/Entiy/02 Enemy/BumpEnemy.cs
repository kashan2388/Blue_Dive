using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpEnemy : MonoBehaviour
{
    // �÷��̾ ���� �ε����� �� ���ظ� �����°�?

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = GetComponent<Player>();

        if(player != null)
        {
            // ��󿡰� ������
            // player.Damage();
        }
    }
}
