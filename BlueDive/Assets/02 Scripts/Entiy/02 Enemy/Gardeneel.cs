using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardeneel : Enemy
{
    // ���� ������
    public override void Attack()
    {
        // �÷��̾�� ���� �ִϸ��̼� �� ����
        if(target != null)
        {
            Damage(damage);
        }
    }
}
