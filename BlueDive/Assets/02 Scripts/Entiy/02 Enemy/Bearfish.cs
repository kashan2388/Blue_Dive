using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bearfish : Enemy
{
    // ū �̻� ��ġ
    [SerializeField] public float damage = 20.0f;   // ������
    [SerializeField] public float coolTime = 1.0f;  // ���� ��Ÿ��   // �ʿ��Ѱ�?
    [SerializeField] WaitForSeconds warningTime = new WaitForSeconds(1.0f);  // ��� �ð�
    [SerializeField] public GameObject warningBlock;    // ��� ���

    public override void Attack()
    {
        // �÷��̾�� ��� �� �ִϸ��̼� �� ����
        Warning();
    }

    IEnumerator Warning()
    {
        warningBlock.SetActive(true);

        yield return warningTime;

        warningBlock.SetActive(false);

        if (target != null)
        {
            // Player.Instance.Damage(damage);
        }
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
