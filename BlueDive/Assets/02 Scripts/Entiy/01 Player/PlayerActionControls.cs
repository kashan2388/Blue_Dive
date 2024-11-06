using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerActionControls 
{
    private Rigidbody2D rb;
    private PlayerStat stats;

    [SerializeField] private int staminaCostToJump = 2;

    public PlayerActionControls(Rigidbody2D rigidbody, PlayerStat playerStats)
    {
        rb = rigidbody;
        stats = playerStats;
    }

    public void PerformHoverJump()
    {
        if (stats.CurrentStamina <= 0) { Debug.Log("CurrentStamina = 0"); return; } 

        stats.ConsumeStamina(staminaCostToJump);
        Vector2 newVelocity = rb.velocity;
        newVelocity.y = stats.CurrentJumpForce;

        rb.velocity = newVelocity;

    }

}
