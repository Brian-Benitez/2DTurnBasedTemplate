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
            if (BarricadeController.Instance.BarricadeHealth > 0)
                CurrentTarget = BarricadeController.Instance.AttackPointsLocation[PickAttackPointOnBarricade()];
            else if (PlayerInfo.instance.CharacterHealthAmount > 0)
                CurrentTarget = PlayerInfo.instance.PlayerObject;

            HaveATarget = true; 
            Debug.Log("The new target is " +  CurrentTarget.name);
        }
        return this;
    }

    public void TurnOffBoolHaveATarget () => HaveATarget = false;
    private int PickAEnemyIndex()
    {
       return Random.Range(0, 10);
    }

    private int PickAttackPointOnBarricade() =>  Random.Range(0, BarricadeController.Instance.AttackPointsLocation.Count);

}
