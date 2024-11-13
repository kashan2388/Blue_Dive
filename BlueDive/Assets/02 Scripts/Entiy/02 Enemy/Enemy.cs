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
    // �ִϸ��̼� ����
    Animator animator;

    public bool isDead => hp <= 0.0f;

    // �ʿ� ����
    // ���� ü��
    // �÷��̾� ��ġ�� ���� �¿� ����
    // ���� �ð����� ����
    // �÷��̾� ���ݿ� ���� �����Ա�

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

    IEnumerator Attack()
    {
        while(true)
        {
            if(Vector2.Distance(target.position, transform.position) <= attackRange)
            {
                // ���� �ڵ�
                // ����ü? ����?

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
        // �״� ����� �ִٸ�
        // animator.SetTrigger("Dead");
    }


}
