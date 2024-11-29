using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Enemy
{
    // 원거리 공격 몬스터
    [SerializeField] public float attack;          // 데미지
    [SerializeField] public float coolTime;        // 공격 쿨타임
    [SerializeField] public GameObject projectile; // 발사체 프리팹


    public override void Attack()
    {
        //투사체 생성 및 플레이어에게 발사
        GameObject projectiles = Instantiate(projectile, transform);
        projectiles.transform.SetParent(transform);
        projectiles.GetComponent<Bullet>().Shot(target);
    }

    public override void CoolTime()
    {
        attackCoolTime = coolTime;
    }
}
