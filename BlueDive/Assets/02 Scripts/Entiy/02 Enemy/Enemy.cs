using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float attackCoolTime = float.MaxValue;   // ���� ��Ÿ��

    public bool isPlaying = false;      // Ȱ��ȭ ����
    private bool isAttack = false;      // ���� ����

    public Transform target = null;     // ��� ��ġ

    
    protected void Start()
    {
        CoolTime();
    }
    protected void Update()
    {
        // Ȱ��ȭ �Ǵ� ���� ��Ÿ���� ���� �ʾ��� ��� ����x
        if (!isPlaying || !isAttack)
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
        float time = attackCoolTime;

        while (time >= 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        isAttack = true;
    }

    /// <summary>
    ///  attackCoolTime �� ������ �� ��
    /// </summary>
    public abstract void CoolTime();



    /// <summary>
    /// ���� ��� ����
    /// player.Damage()
    /// </summary>
    public abstract void Attack();
}
