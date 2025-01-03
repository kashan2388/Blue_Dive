using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerInputManager))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerStat playerStat { get; private set; }


    private PlayerInputManager playerInputManager;
    private HookController hookController;
    private Rigidbody2D rb;

    // GroundCheck 
    [SerializeField] private LayerMask groundLayer;
    private Transform groundCheck;
    private Transform detectObject;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] private bool isGrounded;
    private float moveDirection;

    [Tooltip("HP")]
    [SerializeField] private PlayerHpGauge playerHPGauge;
    [SerializeField] private float HPDrainInterval = 1;
    [SerializeField] private int HPconsumeValue = 1;
    private Coroutine HpDrainCoroutine;



    private void Awake()
    {
        if (Instance == null)
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
        //playerInputManager = GetComponent<PlayerInputManager>();
        hookController = GetComponent<HookController>();
        playerHPGauge = FindObjectOfType<PlayerHpGauge>();

        groundCheck = transform.Find("GroundCheck");
        detectObject = transform.Find("DetectObject");

    }
    private void Start()
    {
        // UpdateHPGauge();
        StartHpDrain();
    }
    private void Update()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            Debug.DrawRay(groundCheck.position, Vector3.down * groundCheckRadius, Color.red);
        }

    }

    private void FixedUpdate()
    {
        HandleSideMovement();
    }

    public void SetGravity(float value)
    {
        playerStat.CurrentGravity = value;

        // Rigidbody2D에 중력 값 적용
        if (rb != null)
        {
            rb.gravityScale = playerStat.CurrentGravity;

        }
    }

    private void HandleSideMovement()
    {
        if (isGrounded && !hookController.IsHookMoving)
        {
            float speed = playerStat.CurrentSpeed;
            rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
        }
    }

    public void Initialize()
    {
        playerStat = new PlayerStat();
        isGrounded = false;

    }

    public void SetMoveDirection(float direction)
    {
        moveDirection = direction;
    }


    private void UpdateHPGauge()
    {
        if (playerHPGauge != null)
        {
            playerHPGauge.UpdateGauge(playerStat.CurrentHP, playerStat.MaxHP);
        }
    }
    private void StartHpDrain()
    {
        if (HpDrainCoroutine == null)
        {
            HpDrainCoroutine = StartCoroutine(ApplyHpDrain());
        }
    }
    private IEnumerator ApplyHpDrain()
    {
        while (true)
        {
            yield return YieldCache.WaitForSeconds(HPDrainInterval);
            playerStat.ConsumeHP(HPconsumeValue);

            UpdateHPGauge();

            if (playerStat.CurrentHP <= 0)
            {
                StopCoroutine(HpDrainCoroutine);
                Dead();
                yield break;
            }

        }
    }

    public void Dead()
    {
        // 플레이어 죽음 시 행동 정의 
        Debug.Log("Player Dead");

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        if (HpDrainCoroutine != null)
        {
            StopCoroutine(HpDrainCoroutine);
            HpDrainCoroutine = null;
        }
    }

}