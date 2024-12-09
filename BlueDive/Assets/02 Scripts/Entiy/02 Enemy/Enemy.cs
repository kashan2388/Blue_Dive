using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float damage = 0;                       // ������
    [SerializeField] public float attackCoolTime = float.MaxValue;  // �ʴ� ���� Ƚ��
    [SerializeField] public bool isPlaying = false;                 // Ȱ��ȭ ����
    [SerializeField] public bool isAttack = true;                   // ���� ����

    protected Transform target = null;                                 // ��� ��ġ


    protected virtual void Update()
    {
        // Ȱ��ȭ �Ǵ� ���� ��Ÿ���� ���� �ʾ��� ��� ����x
        if (!isPlaying || !isAttack || target == null)
            return;

        StartCoroutine(IECoolTime());
        Attack();
    }

    // RangeDetection���κ��� �÷��̾� ��ġ �޾ƿ���
    public void TargetTransform(Transform player)
    {
        target = player;
    }

    // ���� ��Ÿ��
    IEnumerator IECoolTime()
    {
        isAttack = false;
        float time = 1.00f / attackCoolTime;

        while (time >= 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        isAttack = true;
    }

    /// <summary>
    /// ���� ��� ����
    /// player.Damage()
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// ���ط�
    /// </summary>
    public void Damage(float damage)
    {
        // player.Damage(damage);
    }
}
