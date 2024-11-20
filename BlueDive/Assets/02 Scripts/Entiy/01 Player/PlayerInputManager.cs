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

    private InputAction m_Player_HookGrab;
    private InputAction m_Player_HookReterieve;
    // private InputAction m_Player_Jump;
    private InputAction m_Player_Interact;
    private InputAction m_Player_SideMove;

    private float moveDirection;

    private void Awake()
    {
        player = GetComponent<Player>();
        hookController = GetComponent<HookController>();
        actions = new PlayerActionControls(GetComponent<Rigidbody2D>(), player.playerStat);
        playerInput = GetComponent<PlayerInput>();

        m_PlayerControls = playerInput.actions.FindActionMap("PlayerControls");

        if (m_PlayerControls != null)
        {
            m_Player_HookGrab = m_PlayerControls.FindAction("HookGrab", true);
            m_Player_HookGrab.started += OnHookGrabStarted;
            m_Player_HookGrab.performed += OnHookGrabPerformed;
            m_Player_HookGrab.canceled += OnHookGrabCanceld;


            m_Player_HookReterieve = m_PlayerControls.FindAction("HookReterieve", true);
            m_Player_HookReterieve.performed += OnHookReterievePerformed;


            m_Player_Interact = m_PlayerControls.FindAction("Interact", true);
            m_Player_Interact.performed += OnInteractPerformed;


            m_Player_SideMove = m_PlayerControls.FindAction("SideMove", true);
            m_Player_SideMove.started += OnSideMoveStarted;
            m_Player_SideMove.performed += OnSideMovePerformed;
            m_Player_SideMove.canceled += OnSideMoveCanceld;

        }
       
    }

    #region HOOKGRAB INPUT
    public void OnHookGrabStarted(InputAction.CallbackContext context)
    {

    }
    public void OnHookGrabPerformed(InputAction.CallbackContext context)
    {
        

    }
    public void OnHookGrabCanceld(InputAction.CallbackContext context)
    {
        if (!hookController.IsIdleState())
        {
            return;
        }

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
        if(hookController.IsMoving)
        {
            Debug.Log("Right Mouse: Hook Retrieve Performed");

            hookController.ChangeState(new HookRetrieveState());
        }
    }

    #endregion

    #region INTERACTT INPUT 
    public void OnInteractPerformed(InputAction.CallbackContext context)
    {

    }
    #endregion

    #region SIDE MOVE 
    public void OnSideMoveStarted(InputAction.CallbackContext context)
    {
        Debug.Log("OnSideMoveStarted");
    }
    public void OnSideMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveDirection = input.x;

        player.SetMoveDirection(moveDirection);
    }
    public void OnSideMoveCanceld(InputAction.CallbackContext context)
    {
        player.SetMoveDirection(0f);

    }
    #endregion

    private void OnEnable()
    {
        foreach (var action in actions)
        {
            if(action != null ) action.Enable();
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
