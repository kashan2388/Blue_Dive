using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float attackRange = 0;      // 공격 사거리
    [SerializeField] public float attackCoolTime = 0;   // 공격 쿨타임

    protected Transform target;
    SpriteRenderer spriteRenderer;
    // 애니메이션 유무
    Animator animator;

    // 필요 구현
    // 플레이어 위치에 따른 좌우 반전
    // 일정 시간마다 공격

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        target = Player.Instance.transform;

        Stat();
        StartCoroutine(IEAttack());
    }

    protected virtual void Update()
    {
        target = Player.Instance.transform;

        // 플레이어 위치에 따른 좌우 반전
        if(target.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipY = true;
        }
    }

    /// <summary>
    /// attackRange와 attackCoolTime 값 설정
    /// </summary>
    public abstract void Stat();

    IEnumerator IEAttack()
    {
        while(true)
        {
            if(Vector2.Distance(target.position, transform.position) <= attackRange)
            {
                Attack();

                // 공격 후 쿨타임 동안 대기
                yield return StartCoroutine(IECoolTime());
            }

            yield return null;
        }
    }

    /// <summary>
    /// 공격 방법 정의
    /// player.Damage()
    /// </summary>
    public abstract void Attack();

    IEnumerator IECoolTime()
    {
        float time = attackCoolTime;

        while(time >= 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
    }
}
