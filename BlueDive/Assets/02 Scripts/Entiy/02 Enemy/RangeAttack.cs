using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Enemy
{
    // 원거리 공격 몬스터
    [SerializeField] public GameObject projectile;      // 발사체 프리팹
    [SerializeField] public float speed = 1.0f;         // 발사체 속도
    [SerializeField] public float range = 1.0f;         // 공격 사거리
    [SerializeField] public bool penetrating = false;   // 벽 관통여부


    public override void Attack()
    {
        //투사체 생성 및 플레이어에게 발사
        GameObject projectiles = Instantiate(projectile, transform);
        projectiles.transform.SetParent(transform);
        projectiles.GetComponent<Bullet>().Information(target.position, damage, speed, range, penetrating);
    }
}
