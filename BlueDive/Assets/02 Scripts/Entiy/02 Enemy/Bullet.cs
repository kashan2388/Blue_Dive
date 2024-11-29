using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] public float damage = 0;          // ���ط�
    [SerializeField] public float speed = 0;           // ����ü �ӵ�
    [SerializeField] public bool penetrating = false;  // �� ���뿩��

    private Transform target;

    private void Update()
    {
        // �ڽ��� ��ġ���� ������ ������ �ӵ��� �̵�
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        // ��ǥ��ġ ���� �� �Ҹ�
        if(transform.position == target.position)
        {
            Destroy(gameObject);
        }
    }

    public void Shot(Transform target)
    {
        this.target = target;
    }

    // ���뿩�ο� ���� ������� �Ҹ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // �÷��̾�� ���� �� �Ҹ�
            Attack();
            Destroy(gameObject);
        }
        else if (!penetrating)
        {
            if (collision.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// �÷��̾�� ���� �ִ� ���
    /// </summary>
    protected abstract void Attack();
}
