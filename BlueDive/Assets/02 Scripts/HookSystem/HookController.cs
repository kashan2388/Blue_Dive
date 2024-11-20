using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    private PlayerStat playerStat;

    [Header("Hook Setting")]
    [SerializeField] public GameObject hookObject;
    [SerializeField] public GameObject hookAnchor;
    [SerializeField] public LineRenderer ropeLineRenderer;
    [SerializeField] public DistanceJoint2D distanceJoint2D;


    [Header("Hook Values")]
    [SerializeField] public float hookLaunchSpeed = 10f;
    [SerializeField] public float hookRetrieveSpeed = 10f;
    [SerializeField] public float limitDistance = 15f;          // 갈고리 거리 제한 
    [SerializeField] public LayerMask GrappleLayer;
    [SerializeField] public LayerMask UnGrappleLayer;
    [SerializeField] private LayerMask hookIgnoreLayer;
    [SerializeField] private Vector2 limiteScreenVector2;       // 스크린 화면 확장 범위 

    private IHookState currentHookState;
    private Vector2 direction;
    private Vector2 hookTargetPosition;
    private bool isWallDetected;
    public bool IsMoving { get; private set; }
    
    public Vector2 GetHookTargetPos() => hookTargetPosition;
    public PlayerStat GetPlayerStat() => playerStat;
    public GameObject HookObject() => hookObject;

    [SerializeField] private string currentStateName;

    private void Start()
    {
        Player player = GetComponent<Player>();
        if(player!=null) { playerStat = player.playerStat; }


        ChangeState(new HookIdleState());
    }


    private void Update()
    {
        currentHookState?.UpdateState(this);
    }

    public void ChangeState(IHookState newState)
    {
        if (currentHookState?.GetType() == newState.GetType())
        {
            Debug.LogWarning("Already in the same state.");
            return;
        }

        currentHookState?.ExitState(this);
        currentHookState = newState;
        currentHookState.EnterState(this);

        currentStateName = newState.GetType().Name;
    }

    public bool SetHookTarget(Vector2 targetPosition)
    {
        
        Vector2 direction = targetPosition - (Vector2)transform.position;

        // Raycast로 목표 지점 확인
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction.normalized,
            Mathf.Infinity, // 최대거리
            GrappleLayer // 후크가 걸릴 수 있는 레이어만 탐색
        );

        if (hit.collider != null)
        {
            hookTargetPosition = hit.point;
            Debug.Log($"Hook target set at: {hookTargetPosition}");
            return true;
        }

        return false;
    }
    public bool IsIdleState() { return currentHookState is HookIdleState; }


    public void DrawRopeLine(Vector2 hookVector)
    {
        Vector2 playerPosition = transform.position;

        ropeLineRenderer.SetPosition(0, playerPosition);
        ropeLineRenderer.SetPosition(1, GetHookTargetPos());
    }

    public void AnchorHook(Vector2 _position)
    {
        hookAnchor.transform.position = _position;
    }

    public void StartPlayerHookMove()
    {
        IsMoving = true;
        distanceJoint2D.enabled = true;
    }
    public void StopPlayerHookMove()
    {
        IsMoving = false;
        distanceJoint2D.enabled = false;
        ChangeState(new HookIdleState());
    }

    public void ResetHook()
    {
        if (currentHookState is HookIdleState)
        {
            Debug.LogWarning("Already in HookIdleState. Reset skipped.");
            return;
        }

        hookObject.SetActive(false);
        ropeLineRenderer.enabled = false;
        
        IsMoving = false;
        ChangeState(new HookIdleState() );
        // StopPlayerHookMove();
    }

    public bool IsWallDetected() => isWallDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & GrappleLayer) != 0)
        {
            isWallDetected = true;
            ResetHook();
            Debug.Log("벽에 충돌. HookMove 종료");
        }
    }



}
