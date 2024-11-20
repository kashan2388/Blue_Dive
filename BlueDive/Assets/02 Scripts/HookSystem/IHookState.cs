using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public interface IHookState
{
    public abstract void EnterState(HookController controller);
    public abstract void UpdateState(HookController controller);
    public abstract void ExitState(HookController controller);
}

public class HookIdleState : IHookState
{
    public void EnterState(HookController controller) { controller.ResetHook(); }

    public void UpdateState(HookController controller) { }

    public void ExitState(HookController controller) { }

}

public class HookChargingState : IHookState
{
    private float chargingTime; 
    public void EnterState(HookController controller)
    {
        controller.HookObject().SetActive(true);
        chargingTime = 0;
    }
    public void UpdateState(HookController controller)
    {
        chargingTime += Time.deltaTime;
    }

    public void ExitState(HookController controller)
    {
        throw new System.NotImplementedException();
    }

    
}

public class HookShootingState : IHookState
{
    public void EnterState(HookController controller)
    {
        Debug.Log("HookShootingEnter");
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
            Debug.Log("Hook reached target. Changing to HookPlayerMoveState.");
            controller.ChangeState(new HookPlayerMoveState());
        }

    }

    public void ExitState(HookController controller)
    {

    }
}


public class HookPlayerMoveState : IHookState
{
    RaycastHit2D objectRay;

    public void EnterState(HookController controller)
    {
        controller.StartPlayerHookMove();
        // controller.ropeLineRenderer.enabled = true;
    }

    public void UpdateState(HookController controller)
    {
        Vector2 playerPosition = controller.transform.position;
        Vector2 targetPosition = controller.GetHookTargetPos();

        float playerHookMoveSpeed = Player.Instance.playerStat.CurrentHookMoveSpeed;

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
        controller.HookObject().transform.position = Vector2.MoveTowards(controller.HookObject().transform.position, controller.transform.position, controller.hookLaunchSpeed * Time.deltaTime);
        controller.DrawRopeLine(controller.transform.position);

        if (Vector2.Distance(controller.HookObject().transform.position, controller.transform.position) < 0.1f)
        {
            
            controller.ChangeState(new HookIdleState());
        }
    }

    public void ExitState(HookController controller)
    {
    }

    private void HookRetrieve()
    {

    }


}

/*public class HookChargingState : IHookState
{
    private float chargingTime;
    public void EnterState(HookController controller)
    {
        // 오류검사 
        if (controller == null || controller.HookObject() == null)
        {
            Debug.LogError("HookController or HookObject is null in HookChargingState.EnterState.");
            return;
        }

        chargingTime = 0;

        // 오류검사 
        if (CursorManager.Instance == null)
        {
            Debug.LogError("CursorManager.Instance is not initialized.");
            return;
        }

        CursorManager.Instance.ChangeCursor(CursorType.ChargingCursor);
        controller.DrawRopeLine(controller.transform.position);
    }
    public void UpdateState(HookController controller)
    {
        chargingTime += Time.deltaTime;

        if (chargingTime >= controller.hookChargingTime)
        {
            controller.ChangeState(new HookChargingState());
        }
    }

    public void ExitState(HookController controller)
    {

    }
}*/