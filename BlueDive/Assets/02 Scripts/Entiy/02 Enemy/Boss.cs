using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] public float moveSpeed;                // ���� �̵��ӵ�
    [SerializeField] public GameObject AttackPrefab1;       // �Թ� ����(�⺻����)
    [SerializeField] public GameObject AttackPrefab2;       // �˼� �������
    [SerializeField] public GameObject AttackPrefab3;       // ���� ������
    private List<GameObject> attack1;
    private GameObject attack2;
    private GameObject attack3;


    private float damage;           // ������
    private float durationTime;     // ���ӽð�
    private float speed;            // �ӵ�
    private float attackCoolTime = float.MaxValue;      // �ʴ� ���� Ƚ��
    public bool isPlaying = false;                      // Ȱ��ȭ ����
    private bool isAttack = true;                       // ���� ����

    public Transform target = null;                     // ��� ��ġ
    private int roll;

    private void Start()
    {
        target = Player.Instance.transform;

        attack2 = Instantiate(AttackPrefab2, transform);
        attack2.SetActive(false);
        attack3 = Instantiate(AttackPrefab3, transform);
        attack3.SetActive(false);
    }

    private void Update()
    {
        Move();

        target = Player.Instance.transform;
        
        // Ȱ��ȭ �Ǵ� ���� ��Ÿ���� ���� �ʾ��� ��� ����x
        if (!isPlaying || !isAttack)
            return;

        AttackType();                   // ���� ��� ����
        StartCoroutine(IECoolTime());   // ���� ��Ÿ��
    }

    private void Move()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void AttackType()
    {
        roll = Random.Range(1, 100);

        if(roll <= 65)          // ���� 1
        {
            attackCoolTime = 0.6f;
            damage = 5.0f;
            speed = 5.0f;
            Attack1();
        }
        else if (roll <= 85)    // ���� 2
        {
            attackCoolTime = 0.2f;
            damage = 15.0f;
            speed = 5.0f;
            durationTime = 2.5f;
            Attack2();
        }
        else                    // ���� 3
        {
            attackCoolTime = 0.15f;
            damage = 30.0f;
            durationTime = 3.5f;
            Attack3();
        }
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

    public void Attack1()   // �⺻ ����
    {
        int count = attack1.Count;
        attack1.Add(Instantiate(AttackPrefab1, transform));
        attack1[count].transform.position = transform.position;   // ���� ���� ������ ����
        attack1[count].GetComponent<Bullet>().Information(target.position, damage, speed, 500f, true);
    }

    public void Attack2()   // �˼� �������
    {
        attack2.transform.position = transform.position - new Vector3(0, 5);    // �������� �ؿ��� ��ȯ
        attack2.SetActive(true);
        // �÷��̾� ��� ���� ����
        // attack2.GetComponent<BossAttack2>().Attack(durationTime);
    }

    public void Attack3()   // ���� ������
    {
        attack3.SetActive(true);
        // �÷��̾� ��� ���� ����
        // attack3.GetComponent<BossAttack3>().Attack(durationTime);
    }


}
