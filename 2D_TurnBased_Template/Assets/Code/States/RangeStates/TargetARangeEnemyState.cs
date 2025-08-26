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
            if (BarricadeController.Instance.BarricadeHealth > 0)
                CurrentRangeTarget = BarricadeController.Instance.BarricadeGameObject;
            else
                CurrentRangeTarget = NPCController.Instance.GoodGuysList[NPCController.Instance.PickGoodGuyAtRandom()];

            TurnOnHasRangeTarget(); 
        }
            return this;
    }



    //Helper functions------------------------------------------------>
    public void TurnOffHasRangeTarget() => HasRangeTarget = false;
    public void TurnOnHasRangeTarget() => HasRangeTarget = true;
}
