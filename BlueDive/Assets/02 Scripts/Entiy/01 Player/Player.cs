using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

    public PlayerStat playerStat { get; private set; }
    private PlayerController playerController;

    private Rigidbody2D rb;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerStat = new PlayerStat();
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToGrabPosition(Vector2 targetPosition)
    {

    }

}
