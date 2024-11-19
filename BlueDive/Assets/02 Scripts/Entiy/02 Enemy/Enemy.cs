using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float attackRange = 0;      // ���� ��Ÿ�
    [SerializeField] public float attackCoolTime = 0;   // ���� ��Ÿ��

    protected Transform target;
    SpriteRenderer spriteRenderer;
    // �ִϸ��̼� ����
    Animator animator;

    // �ʿ� ����
    // �÷��̾� ��ġ�� ���� �¿� ����
    // ���� �ð����� ����

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

        // �÷��̾� ��ġ�� ���� �¿� ����
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
    /// attackRange�� attackCoolTime �� ����
    /// </summary>
    public abstract void Stat();

    IEnumerator IEAttack()
    {
        while(true)
        {
            if(Vector2.Distance(target.position, transform.position) <= attackRange)
            {
                Attack();

                // ���� �� ��Ÿ�� ���� ���
                yield return StartCoroutine(IECoolTime());
            }

            yield return null;
        }
    }

    /// <summary>
    /// ���� ��� ����
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
