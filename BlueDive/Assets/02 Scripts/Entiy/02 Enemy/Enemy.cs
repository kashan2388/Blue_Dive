using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float damage = 0;                       // 데미지
    [SerializeField] public float attackCoolTime = float.MaxValue;  // 초당 공격 횟수
    [SerializeField] public bool isPlaying = false;                 // 활성화 여부
    [SerializeField] public bool isAttack = true;                   // 공격 여부

    protected Transform target = null;                                 // 대상 위치


    protected virtual void Update()
    {
        // 활성화 또는 공격 쿨타임이 되지 않았을 경우 공격x
        if (!isPlaying || !isAttack || target == null)
            return;

        StartCoroutine(IECoolTime());
        Attack();
    }

    // RangeDetection으로부터 플레이어 위치 받아오기
    public void TargetTransform(Transform player)
    {
        target = player;
    }

    // 공격 쿨타임
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
    /// 공격 방법 정의
    /// player.Damage()
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// 피해량
    /// </summary>
    public void Damage(float damage)
    {
        // player.Damage(damage);
    }
}
