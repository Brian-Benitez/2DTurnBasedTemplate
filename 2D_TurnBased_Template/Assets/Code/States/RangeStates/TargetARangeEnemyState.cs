using UnityEngine;

public class TargetARangeEnemyState : State
{
    [Header("Booleans")]
    public bool HasRangeTarget = false;

    [Header("Target")]
    public GameObject CurrentRangeTarget;

    GetWithinRangeAttackState GetWithinRangeAttackState;


    private void Start()
    {
        GetWithinRangeAttackState = GetComponent<GetWithinRangeAttackState>();
    }
    public override State RunCurrentState()
    {
        if(HasRangeTarget)
            return GetWithinRangeAttackState;
        else
        {
            //CurrentRangeTarget = NPCController.Instance.Player;
            TurnOnHasRangeTarget(); 
        }
            return this;
    }



    //Helper functions------------------------------------------------>
    public void TurnOffHasRangeTarget() => HasRangeTarget = false;
    public void TurnOnHasRangeTarget() => HasRangeTarget = true;
}
