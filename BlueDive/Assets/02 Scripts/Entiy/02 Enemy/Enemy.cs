using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float attackCoolTime = float.MaxValue;    // �ʴ� ���� Ƚ��
    public bool isPlaying = false;                   // Ȱ��ȭ ����
    private bool isAttack = true;                       // ���� ����
    // private bool isAnim = false;                     // �ִϸ��̼� ����

    public Transform target = null;                     // ��� ��ġ

    
    protected virtual void Start()
    {
        CoolTime();
    }
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
    ///  attackCoolTime �� ������ �� ��
    /// </summary>
    public abstract void CoolTime();



    /// <summary>
    /// ���� ��� ����
    /// player.Damage()
    /// </summary>
    public abstract void Attack();
}
