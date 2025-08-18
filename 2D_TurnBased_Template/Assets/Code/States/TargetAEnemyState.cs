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
    int _newEnemyIndex = 0;

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
            {
                PickAttackPointOnBarricade();
                CurrentTarget = BarricadeController.Instance.AttackPointsLocation[_newEnemyIndex];
            }
            //add player health stuff here

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

    private void PickAttackPointOnBarricade()
    {
        _newEnemyIndex = 0;
        Debug.Log("checek " + BarricadeController.Instance.AttackPointsLocation.Count);
       _newEnemyIndex =  Random.Range(0, BarricadeController.Instance.AttackPointsLocation.Count);
    }

}
