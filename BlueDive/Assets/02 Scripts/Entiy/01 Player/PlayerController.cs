using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private InputActionMap m_Player;

    private InputAction m_Player_hookGrab;
    private InputAction m_Player_hookAttack;
    private InputAction m_Player_Jump;
    private InputAction m_Player_Interact;


    private void Awake()
    {
        player = GetComponent<Player>();

        PlayerInput playerInput = GetComponent<PlayerInput>();
        m_Player = playerInput.actions.FindActionMap("PlayerControls");

        if (m_Player != null)
        {
            m_Player_hookGrab = m_Player.FindAction("HookGrab", true);
            m_Player_hookAttack = m_Player.FindAction("HookAttack", true);
            m_Player_Jump = m_Player.FindAction("Jump", true);
            m_Player_Interact = m_Player.FindAction("Interact", true);

            m_Player_hookGrab.started += OnHookGrabStarted;
            m_Player_hookGrab.performed += OnHookGrabPerformed;
            m_Player_hookGrab.canceled += OnHookGrabCanceled;



            m_Player_hookAttack.started += OnHookAttackStarted;
            m_Player_hookAttack.performed += OnHookAttackPerformed;
            m_Player_hookAttack.canceled += OnHookAttackCanceld;


            m_Player_Jump.started += OnJumpStarted;
            m_Player_Jump.performed += OnJumpPerformed;
            m_Player_Jump.performed += OnJumpCanceld;

            m_Player_Interact.started += OnInteractStarted;
            m_Player_Interact.performed += OnInteractPerformed;
            m_Player_Interact.canceled += OnInteractCanceld;

        }
    }

    // HookGrab 
    public void OnHookGrabStarted(InputAction.CallbackContext context)
    {
        Debug.Log("HookGrab started");
    }
    public void OnHookGrabPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("HookGrab Performed");
    }
    public void OnHookGrabCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("HookGrab canceled");
    }

    // HookAttack 
    public void OnHookAttackStarted(InputAction.CallbackContext context)
    {
        Debug.Log("HookAttack started");
    }
    public void OnHookAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("HookAttack Performed");
    }
    public void OnHookAttackCanceld(InputAction.CallbackContext context)
    {
        Debug.Log("HookAttack canceled");
    }


    // OnJump
    public void OnJumpStarted(InputAction.CallbackContext context)
    {

    }
    public void OnJumpPerformed(InputAction.CallbackContext context)
    {

    }
    public void OnJumpCanceld(InputAction.CallbackContext context)
    {

    }

    //OnInteract
    public void OnInteractStarted(InputAction.CallbackContext context)
    {

    }
    public void OnInteractPerformed(InputAction.CallbackContext context)
    {

    }
    public void OnInteractCanceld(InputAction.CallbackContext context)
    {

    }


    private void OnEnable()
    {
        m_Player_hookGrab.Enable();
        m_Player_hookAttack.Enable();
        m_Player_Jump.Enable();
        m_Player_Interact.Enable();

    }

    private void OnDisable()
    {
        m_Player_hookGrab.Disable();
        m_Player_hookAttack.Disable();
        m_Player_Jump.Disable();
        m_Player_Interact.Disable();
    }

}
