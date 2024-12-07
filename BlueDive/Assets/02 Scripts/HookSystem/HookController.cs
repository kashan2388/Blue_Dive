using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookController : MonoBehaviour
{
    private Player player;
    private Hook hookObject;
    private GameObject hookAnchor;
    private LineRenderer ropeLineRenderer;
    private DistanceJoint2D distanceJoint2D;

    #region Hook & Laser Setting
   
    [Header("Hook Values")]
    [SerializeField] public float hookLaunchSpeed = 10f;
    [SerializeField] public float hookRetrieveSpeed = 50f;
    [SerializeField] public float limitDistance = 15f;          // ���� �Ÿ� ���� 
    [SerializeField] public LayerMask GrappleLayer;
    [SerializeField] public LayerMask UnGrappleLayer;
    [SerializeField] private LayerMask hookIgnoreLayer;
    [SerializeField] private Vector2 limiteScreenVector2;       // ��ũ�� ȭ�� Ȯ�� ���� 

    [Space(15)]
    [Header("Laser Setting")]
    [SerializeField] private GameObject playerLaserObject;
    [SerializeField] private LineRenderer targetLineRenderer;
    [SerializeField] private GameObject targetAnchor;

    // ��ũ ���̴� ���� üũ
    private int ropeAnchor = 0;
    private Queue<Vector3> ropeAnchorVector = new Queue<Vector3>();

    private IHookState currentHookState;
    private Vector2 hookTargetPosition;

    #endregion
    [SerializeField] private string currentStateName;
    public bool IsHookMoving { get; private set; }
    public Vector2 GetHookTargetPos() => hookTargetPosition;
    public Hook HookObject() => hookObject;
    public bool IsWallDetected { get; private set; }


    private void Awake()
    {
        player = GetComponent<Player>();

        hookObject = FindObjectOfType<Hook>();
        hookAnchor = hookObject.transform.GetChild(1).gameObject;
        ropeLineRenderer = hookObject.transform.GetChild(0).GetComponent<LineRenderer>();
        distanceJoint2D = hookObject.GetComponent<DistanceJoint2D>();
        
        distanceJoint2D.connectedBody = gameObject.GetComponent<Rigidbody2D>();

        playerLaserObject = GameObject.FindGameObjectWithTag("PlayerLaser");
        targetLineRenderer = playerLaserObject.transform.GetChild(0).GetComponent<LineRenderer>();
        targetAnchor = playerLaserObject.transform.GetChild(1).gameObject;

        ropeLineRenderer.positionCount = 2;
        ropeLineRenderer.useWorldSpace = true;
        distanceJoint2D.enableCollision = false;
        hookObject.gameObject.SetActive(false);

        playerLaserObject.SetActive(false);

    }
    private void Start()
    {
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
            if (!IsIdleState())
                Debug.LogWarning("Already in the same state.");
            return;
        }

        currentHookState?.ExitState(this);
        currentHookState = newState;
        currentHookState.EnterState(this);

        currentStateName = newState.GetType().Name; // ������
    }

    public bool SetHookTarget(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction.normalized,
            Mathf.Infinity, // �ִ�Ÿ�
            GrappleLayer
        );

        if (hit.collider != null)
        {
            hookTargetPosition = hit.point;

            return true;
        }

        return false;
    }
    public bool IsIdleState() { return currentHookState is HookIdleState; }
    public bool IsReterieveState() { return currentHookState is HookRetrieveState; }

    #region DrawRopeLine & Hook
    private void HookArrowRotation(Vector3 target)
    {
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, 10000);
        hookObject.transform.rotation = rotation;
    }
    public void MoveToHookObject()
    {
        hookObject.gameObject.transform.position = Vector2.MoveTowards
            (hookObject.gameObject.transform.position, hookTargetPosition, Time.deltaTime * hookLaunchSpeed);

    }
    public bool HookPossibleCheck(Vector2 point)
    {
        Vector2 hookPointScreenVector2 = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (hookPointScreenVector2.x < 0 - limiteScreenVector2.x
            || hookPointScreenVector2.x > Screen.width + limiteScreenVector2.x
            || hookPointScreenVector2.y < 0 - limiteScreenVector2.y
            || hookPointScreenVector2.y > Screen.height + limiteScreenVector2.y )
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void TargetLaserReset()
    {
        targetLineRenderer.SetPosition(0,transform.position);
        targetLineRenderer.SetPosition(1, transform.position);
        targetAnchor.transform.position = transform.position;
    }
    public void AnchorHook(Vector2 _position)
    {
        hookAnchor.transform.position = _position;
    }

    public void ConfigureLineRenderer(Vector2 start, Vector2 end)
    {
        ropeLineRenderer.enabled = true;
        ropeLineRenderer.positionCount = 2;
        ropeLineRenderer.SetPosition(0, start);
        ropeLineRenderer.SetPosition(1, end);
    }
    public void DrawRopeLine(Vector2 hookVector)
    {
        ropeLineRenderer.enabled = true;
        ropeLineRenderer.SetPosition(0, transform.position);
        ropeLineRenderer.SetPosition(1, hookAnchor.transform.position);
    }

    #endregion


    #region PlayerMove
    public void StartPlayerHookMove()
    {
        IsHookMoving = true;
        distanceJoint2D.enabled = true;
    }
    public void StopPlayerHookMove()
    {
        IsHookMoving = false;
        distanceJoint2D.enabled = false;
        ChangeState(new HookIdleState());
    }
    #endregion

    public void ResetHook()
    {
        hookObject.gameObject.SetActive(false);
        ropeLineRenderer.enabled = false;

        IsHookMoving = false;
        IsWallDetected = false;
        ChangeState(new HookIdleState());
        StopPlayerHookMove();

        if (IsIdleState())
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & GrappleLayer) != 0)
        {
            IsWallDetected = true;
            ResetHook();
        }
    }



}