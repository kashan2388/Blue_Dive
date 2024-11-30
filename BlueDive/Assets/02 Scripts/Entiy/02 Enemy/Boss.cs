using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] public GameObject AttackPrefab1;      // 기본공격
    [SerializeField] public GameObject AttackPrefab2;      // 촉수 내려찍기
    [SerializeField] public GameObject AttackPrefab3;      // 강력 물대포
    private GameObject attack2;
    private GameObject attack3;


    private float damage;           // 데미지
    private float durationTime;     // 지속시간
    private float speed;            // 속도
    private float attackCoolTime = float.MaxValue;      // 초당 공격 횟수
    public bool isPlaying = false;                      // 활성화 여부
    private bool isAttack = true;                       // 공격 여부

    public Transform target = null;                     // 대상 위치
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
        target = Player.Instance.transform;

        // 카메라 위치에 맞춰 움직이는가?
        // 플레이어 위치에 맞춰 움직이는가?

        // 활성화 또는 공격 쿨타임이 되지 않았을 경우 공격x
        if (!isPlaying || !isAttack)
            return;

        AttackType();                   // 공격 방식 선택
        StartCoroutine(IECoolTime());   // 공격 쿨타임
    }

    private void AttackType()
    {
        roll = Random.Range(1, 100);

        if(roll <= 65)
        {
            CoolTime(0.6f);
            damage = 5.0f;
            speed = 5.0f;
            Attack1();
        }
        else if (roll <= 85)
        {
            CoolTime(0.2f);
            damage = 15.0f;
            speed = 5.0f;
            durationTime = 2.5f;
            Attack2();
        }
        else
        {
            CoolTime(0.15f);
            damage = 30.0f;
            durationTime = 3.5f;
            Attack3();
        }
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
    public void CoolTime(float value)
    {
        attackCoolTime = 1.00f / value;
    }

    public void Attack1()   // 기본 공격
    {
        GameObject projectiles = Instantiate(AttackPrefab1, transform);
        projectiles.transform.SetParent(transform);
        projectiles.GetComponent<Bullet>().Shot(target, damage, speed, true);
    }
    public void Attack2()   // 촉수 내려찍기
    {
        attack2.transform.position = transform.position - new Vector3(0, 5);    // 보스보다 밑에서 소환
        attack2.SetActive(true);
        // 플레이어 대상 공격 실행
        // attack2.GetComponent<BossAttack2>().Attack(durationTime);
    }
    public void Attack3()   // 강력 물대포
    {
        attack3.SetActive(true);
        // 플레이어 대상 공격 실행
        // attack3.GetComponent<BossAttack3>().Attack(durationTime);
    }


}
