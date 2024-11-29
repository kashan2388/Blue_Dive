using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float attackCoolTime = float.MaxValue;   // 공격 쿨타임

    public bool isPlaying = false;      // 활성화 여부
    private bool isAttack = false;      // 공격 여부

    public Transform target = null;     // 대상 위치

    
    protected void Start()
    {
        CoolTime();
    }
    protected void Update()
    {
        // 활성화 또는 공격 쿨타임이 되지 않았을 경우 공격x
        if (!isPlaying || !isAttack)
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
        float time = attackCoolTime;

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
