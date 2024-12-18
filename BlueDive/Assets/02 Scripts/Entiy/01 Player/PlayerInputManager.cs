using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private Player player;
    private HookController hookController;
    private PlayerInput playerInput;
    private PlayerActionControls actions;
    private InputActionMap m_PlayerControls;

    private InputAction hookGrapAction;
    private InputAction hookRetriveAction;
    private InputAction interactAction;
    private InputAction sideMoveAction;

    private void Awake()
    {
        player = GetComponent<Player>();
        hookController = GetComponent<HookController>();
        actions = new PlayerActionControls(GetComponent<Rigidbody2D>(), player.playerStat);
        playerInput = GetComponent<PlayerInput>();

        m_PlayerControls = playerInput.actions.FindActionMap("PlayerControls");

        if (m_PlayerControls != null)
        {
            InitializeActions();
        }

    }

    private void InitializeActions()
    {
        var hookGrapAction = m_PlayerControls.FindAction("HookGrab", true);
        hookGrapAction.started += OnHookGrabStarted;
        hookGrapAction.canceled += OnHookGrabCanceld;


        var hookRetriveAction = m_PlayerControls.FindAction("HookReterieve", true);
        hookRetriveAction.performed += OnHookReterievePerformed;


        var interactAction = m_PlayerControls.FindAction("Interact", true);
        interactAction.performed += OnInteractPerformed;


        var sideMoveAction = m_PlayerControls.FindAction("SideMove", true);
        sideMoveAction.started += OnSideMoveStarted;
        sideMoveAction.performed += OnSideMovePerformed;
        sideMoveAction.canceled += OnSideMoveCanceld;
    }

    #region HOOKGRAB INPUT
    public void OnHookGrabStarted(InputAction.CallbackContext context)
    {
        if (!hookController.IsIdleState() || hookController.IsReterieveState() || hookController.IsHookMoving)
        {
            return;
        }
        hookController.ChangeState(new HookChargingState());
    }

    public void OnHookGrabCanceld(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (hookController.SetHookTarget(mousePosition))
        {
            hookController.ChangeState(new HookShootingState());
        }
    }
    #endregion 

    #region HOOKRETERIEVE INPUT 
    public void OnHookReterievePerformed(InputAction.CallbackContext context)
    {
        if (hookController.IsHookMoving == true)
        {
            hookController.ChangeState(new HookRetrieveState());
        }
    }
    #endregion

    #region SIDE MOVE 
    public void OnSideMoveStarted(InputAction.CallbackContext context)
    {
    }
    public void OnSideMovePerformed(InputAction.CallbackContext context)
    {
        float moveDirection = context.ReadValue<Vector2>().x; ;
        player.SetMoveDirection(moveDirection);
    }
    public void OnSideMoveCanceld(InputAction.CallbackContext context)
    {
        player.SetMoveDirection(0f);
    }
    #endregion

    #region INTERACTT INPUT 
    public void OnInteractPerformed(InputAction.CallbackContext context)
    {

    }
    #endregion

   

    private void OnEnable()
    {
        foreach (var action in actions)
        {
            if (action != null) action.Enable();
        }

    }

    private void OnDisable()
    {
        foreach (var action in actions)
        {
            if (action != null) action.Disable();
        }
    }

}