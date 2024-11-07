using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHookState
{
    void EnterState(HookController controller);
    void UpdateState(HookController controller);
    void ExitState(HookController controller);
}

public class HookIdleState : IHookState
{
    public void EnterState(HookController controller)
    {
        
    }

    public void ExitState(HookController controller)
    {
        
    }

    public void UpdateState(HookController controller)
    {
        
    }
}
public class HookShootingState : IHookState
{
    public void EnterState(HookController hookController)
    {
        hookController.hookObject.SetActive(true);
    }

    public void ExitState(HookController hookController)
    {
        if (Vector2.Distance(hookController.transform.position, hookController.HookTargetPos()) > hookController.limitDistance)
        {
            hookController.ChangeState(new HookRetrieveState());
        }
    }

    public void UpdateState(HookController hookController)
    {
        throw new System.NotImplementedException();
    }
}
public class Grappling : IHookState
{
    public void EnterState(HookController hookController)
    {
        hookController.hookObject.SetActive(true);
    }

    public void ExitState(HookController hookController)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState(HookController hookController)
    {
        throw new System.NotImplementedException();
    }
}
public class HookChargingState : IHookState
{
    public void EnterState(HookController controller)
    {
        throw new System.NotImplementedException();
    }

    public void ExitState(HookController controller)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState(HookController controller)
    {
        throw new System.NotImplementedException();
    }
}
public class HookRetrieveState : IHookState
{
    public void EnterState(HookController controller)
    {
        throw new System.NotImplementedException();
    }

    public void ExitState(HookController controller)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState(HookController controller)
    {
        throw new System.NotImplementedException();
    }
}