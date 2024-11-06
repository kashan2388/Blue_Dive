using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    // 플레이어
    private PlayerController playerController;
    private Rigidbody2D playerRigid;

    public GameObject hookObject;
    [SerializeField] private GameObject hookAnchor;

    [SerializeField] private LayerMask hookGrappleLayerMask;
    [SerializeField] private LayerMask hookAttackableLayerMask;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private LayerMask ignoremasek;

    [SerializeField] private LineRenderer ropeLineRenderer;
    [SerializeField] private DistanceJoint2D distanceJoint;
    [SerializeField] private Vector2 limiteScreenVector2;


    public float hookLaunchSpeed = 10f;
    public float hookChargingTime = 1.0f;
    private float currentChargingTime = 0f;
    public float limitDistance = 15f;
    public float hookPlayerSpeed = 5f;
    public float hookRetriveSpeed = 10f;

    private Vector2 hookTargetpos;
    private Vector2 dierection;
    private Vector2 currentMousePosition;

    private IHookState currentHookState;

    public Vector2 HookTargetPos() => hookTargetpos;

    private void Start()
    {
        ChangeState(new HookIdleState());
    }


    private void Update()
    {
        
    }

    public void HandleHookCharging()
    {

    }

    private void ChargeHook()
    {

    }


    public void ChangeState(IHookState newState)
    {
        currentHookState?.ExitState(this);
        currentHookState = newState;
        currentHookState.EnterState(this);
    }

}
