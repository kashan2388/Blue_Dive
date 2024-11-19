using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeed : Enemy
{
    private float pullForce = 1;    // ´ç±â´Â Èû

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Stat()
    {
        attackRange = 0;
        attackCoolTime = float.MaxValue;
    }

    public override void Attack()
    {
        Vector2 moveVector = (transform.position - target.position).normalized * pullForce;

        target.GetComponent<Rigidbody2D>().velocity = moveVector;
    }
}
