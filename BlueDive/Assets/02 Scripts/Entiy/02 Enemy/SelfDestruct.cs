using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // �����
    [SerializeField] public float range;    // �Ÿ�
    [SerializeField] public float damage;   // ������
    private WaitForSeconds waitingTime = new WaitForSeconds(3.0f);  // ���� ���ð�

    public override void Attack()
    {
        StartCoroutine(IEBoom());
        // �÷��̾ ������?
        // �÷��̾ 1m�̳��϶�?

    }

    IEnumerator IEBoom()
    {
        yield return waitingTime;

        if (Distance(transform) <= range)
        {

            // ���� ����Ʈ ����
            // ������ ���� ����Ʈ�� �÷��̾ ���� ��� �÷��̾�� ������

        }

        Destroy(this);
    }

    private float Distance(Transform transform)
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);

        return distance;
    }

    public override void CoolTime()
    {
        throw new System.NotImplementedException();
    }
}
