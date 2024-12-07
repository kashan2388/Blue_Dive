using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private float currentMoveSpeed;
    private float currentHookMoveSpeed;

    public Movement(Rigidbody2D rb, float initialSpeed)
    {
        this.rb = rb;
        currentMoveSpeed = initialSpeed;
    }

    public void SetGroundedState(bool grounded)
    {
        isGrounded = grounded;
    }

    public void SideMove(Vector2 direction)
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(direction.x * currentMoveSpeed, direction.y);
        }
    }


    public void MoveToGrabTarget(Vector2 targetPosition, float hookMoveSpeed)
    {
        rb.transform.position = Vector2.MoveTowards(
            rb.transform.position,
            targetPosition,
            hookMoveSpeed * Time.deltaTime
        );
    }

    public float GetDistanceToTarget(Vector2 targetPosition)
    {
        return Vector2.Distance(rb.transform.position, targetPosition);
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }
}
