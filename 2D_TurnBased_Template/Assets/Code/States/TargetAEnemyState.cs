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
    public int GoodGuyIndex = 0;

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
            if (BarricadeController.Instance.BarricadeHealth > 0)// if ther barricade got health,go to it!
            {
                PickAttackPointOnBarricade();
                CurrentTarget = BarricadeController.Instance.AttackPointsLocation[_newEnemyIndex];
            }
            else//if not pick a good guy to go to
            {
                CurrentTarget = NPCController.Instance.GoodGuysList[NPCController.Instance.PickGoodGuyAtRandom()];
            }

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
