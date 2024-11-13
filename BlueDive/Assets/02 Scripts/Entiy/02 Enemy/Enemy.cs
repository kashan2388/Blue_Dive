using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float attackRange;
    [SerializeField] float attackCoolTime;

    protected Transform target;
    private float hp = 1.0f;
    SpriteRenderer spriteRenderer;
    // 애니메이션 유무
    Animator animator;

    public bool isDead => hp <= 0.0f;

    // 필요 구현
    // 몬스터 체력
    // 플레이어 위치에 따른 좌우 반전
    // 일정 시간마다 공격
    // 플레이어 공격에 의한 피해입기

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        hp = maxHp;

        StartCoroutine(Attack());
    }

    private void Update()
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

    IEnumerator Attack()
    {
        while(true)
        {
            if(Vector2.Distance(target.position, transform.position) <= attackRange)
            {
                // 공격 코드
                // 투사체? 돌진?

                yield return StartCoroutine(CoolTime());
            }
            yield return null;
        }
    }

    IEnumerator CoolTime()
    {
        float time = attackCoolTime;

        while(time >= 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
    }

    public void Damage(float value)
    {
        hp -= value;
        
        if (isDead)
            Dead();
    }

    public void Dead()
    {
        // 죽는 모션이 있다면
        // animator.SetTrigger("Dead");
    }


}
