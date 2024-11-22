using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public interface IHookState
{
    public abstract void EnterState(HookController controller);
    public abstract void UpdateState(HookController controller);
    public abstract void ExitState(HookController controller);
}

public class HookIdleState : IHookState
{
    Player player = Player.Instance;
    public void EnterState(HookController controller) 
    {
        player.SetGravity(player.playerStat.defaultGravity);

        controller.ResetHook();

        controller.ChangeState(new HookRetrieveState());
    }

    public void UpdateState(HookController controller) { }

    public void ExitState(HookController controller) { }

}

public class HookChargingState : IHookState
{
    private LineRenderer lineRenderer;

    public void EnterState(HookController controller)
    {
        Debug.Log("Entered Charging State");

        lineRenderer = controller.ropeLineRenderer;
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, controller.transform.position);
        lineRenderer.SetPosition(1, controller.transform.position); 
    }

    public void UpdateState(HookController controller)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        lineRenderer.SetPosition(0, controller.transform.position);
        lineRenderer.SetPosition(1, mousePosition);

        Debug.Log($"Charging... Mouse Position: {mousePosition}");
    }

    public void ExitState(HookController controller)
    {
        controller.ropeLineRenderer.enabled = false;
    }
}

public class HookShootingState : IHookState
{
    public void EnterState(HookController controller)
    {
        controller.HookObject().SetActive(true);
        controller.ropeLineRenderer.enabled = true;
        controller.ropeLineRenderer.SetPosition(0, controller.transform.position);
        controller.ropeLineRenderer.SetPosition(1, controller.GetHookTargetPos());
    }

    public void UpdateState(HookController controller)
    {
        Vector2 currenHookPosition = controller.HookObject().transform.position;
        Vector2 targetPosition = controller.GetHookTargetPos();

        controller.HookObject().transform.position = Vector2.MoveTowards(
            currenHookPosition,
            targetPosition,
            controller.hookLaunchSpeed * Time.deltaTime
        );

        controller.DrawRopeLine(controller.transform.position);

        if (Vector2.Distance(currenHookPosition, targetPosition) < 0.1f)
        {
            controller.ChangeState(new HookPlayerMoveState());
        }

    }

    public void ExitState(HookController controller)
    {
       

    }
}


public class HookPlayerMoveState : IHookState
{
    Player player = Player.Instance;
    RaycastHit2D objectRay;

    public void EnterState(HookController controller)
    {
        controller.StartPlayerHookMove();

    }

    public void UpdateState(HookController controller)
    {
        Vector2 playerPosition = controller.transform.position;
        Vector2 targetPosition = controller.GetHookTargetPos();

        float playerHookMoveSpeed = Player.Instance.playerStat.CurrentHookMoveSpeed;

        player.SetGravity(0);

        controller.transform.position = Vector2.MoveTowards(
            playerPosition,
            targetPosition,
            playerHookMoveSpeed * Time.deltaTime
        );

        controller.DrawRopeLine(targetPosition); ;

        if (Vector2.Distance(playerPosition, targetPosition) <= 0.5f
           || controller.IsWallDetected())
        {
            controller.ChangeState(new HookIdleState());
            controller.StopPlayerHookMove();
        }

    }

    public void ExitState(HookController controller)
    {
        controller.ropeLineRenderer.enabled = false;
    }
}

public class HookRetrieveState : IHookState
{
    public void EnterState(HookController controller)
    {
        // controller.DrawRopeLine();
    }

    public void UpdateState(HookController controller)
    {
        controller.HookObject().transform.position = Vector2.MoveTowards(controller.HookObject().transform.position, controller.transform.position, controller.hookRetrieveSpeed * Time.deltaTime);
        controller.DrawRopeLine(controller.transform.position);

        if (Vector2.Distance(controller.HookObject().transform.position, controller.transform.position) < 0.1f)
        {
            controller.ChangeState(new HookIdleState());
        }
    }

    public void ExitState(HookController controller)
    {
        
    }



}
