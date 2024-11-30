using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float attackCoolTime = float.MaxValue;    // 초당 공격 횟수
    public bool isPlaying = false;                   // 활성화 여부
    private bool isAttack = true;                       // 공격 여부
    // private bool isAnim = false;                     // 애니메이션 여부

    public Transform target = null;                     // 대상 위치

    
    protected virtual void Start()
    {
        CoolTime();
    }
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
    ///  attackCoolTime 값 재정의 할 것
    /// </summary>
    public abstract void CoolTime();



    /// <summary>
    /// 공격 방법 정의
    /// player.Damage()
    /// </summary>
    public abstract void Attack();
}
