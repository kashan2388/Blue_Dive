using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerInputManager))]
public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

    public PlayerStat playerStat { get; private set; }
    private PlayerInputManager playerInputManager;
    private HookController hookController;

    // GroundCheck 
    [SerializeField] private LayerMask groundLayer;
    private Transform groundCheck;
    private Transform detectObject;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    private float moveDirection;

    // Stamina
    [SerializeField] private static float staminaDrainInterval = 1;
    [SerializeField] private float consumeValue = 0.5f;
    private Coroutine staminaDrainCoroutine;



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
        playerInputManager = GetComponent<PlayerInputManager>();
        hookController = GetComponent<HookController>();

        groundCheck = transform.Find("GroundCheck");
        if (groundCheck == null) Debug.Log("GroundCheck ChildObject Missing!");

        detectObject = transform.Find("DetectObject");

    }

    private void Update()
    {
        if(groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            Debug.DrawRay(groundCheck.position, Vector3.down * groundCheckRadius, Color.red);
        }

    }

    private void FixedUpdate()
    {
        HandleSideMovement();
    }

    private void HandleSideMovement()
    {
        if (isGrounded && !hookController.IsMoving)
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


    public void MoveToGrabPosition(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * playerStat.CurrentHookMoveSpeed;
    }

    private void StartStaminaDrain()
    {
        if (staminaDrainCoroutine == null)
        {
            staminaDrainCoroutine = StartCoroutine(ApplyStaminaDrain());
        }
    }
    private IEnumerator ApplyStaminaDrain()
    {
        while(true)
        {
            yield return YieldCache.WaitForSeconds(staminaDrainInterval);
            playerStat.ConsumeStamina(consumeValue);

        }
    }

    public void Dead()
    {
        Debug.Log("Player Dead");

    }

    private void OnEnable()
    {
        //  StartStaminaDrain();
    }

    private void OnDisable()
    {
        if(staminaDrainCoroutine != null)
        {
            StopCoroutine(staminaDrainCoroutine);
            staminaDrainCoroutine = null;
        }
    }

}
