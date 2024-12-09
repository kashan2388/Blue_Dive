using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // �����
    [SerializeField] public float range = 3.0f;    // �Ÿ�
    private WaitForSeconds waitingTime = new WaitForSeconds(3.0f);  // ���� ���ð�

    public override void Attack()
    {
        StartCoroutine(IEBoom());
    }

    IEnumerator IEBoom()
    {
        yield return waitingTime;

        // ���� ����Ʈ ����

        if (Distance() <= range)
        {
            Damage(damage);
        }

        Destroy(this);
    }

    private float Distance()
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);

        return distance;
    }
}
