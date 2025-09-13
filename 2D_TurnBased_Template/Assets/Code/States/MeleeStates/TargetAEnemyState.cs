using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TargetAEnemyState : State
{
    [Header("State")]
    ChaseState ChaseState;
    [Header("Bool")]
    public bool HaveATarget = false;
    [Header("Current obj target")]
    public GameObject CurrentTarget;

    private void Start()
    {
        ChaseState = GetComponent<ChaseState>();
    }

    public override State RunCurrentState()
    {   
        if(HaveATarget)
            return ChaseState;

        else if(!HaveATarget)
        {
            CurrentTarget = NPCController.Instance.GoodGuysList[NPCController.Instance.PickGoodGuyAtRandom()];
            ChaseState.RestartDistance();
            TurnOnHaveATarget();
        }
        return this;
    }

    public void TurnOnHaveATarget() => HaveATarget = true;
    public void TurnOffBoolHaveATarget () => HaveATarget = false;

}
