using UnityEngine;

public class TargetAEnemyState : State
{
    [Header("State")]
    public ChaseState ChaseState;

    public bool HaveATarget = false;
    public Transform CurrentTarget;

    public override State RunCurrentState()
    {   
        if(HaveATarget)
            return ChaseState;
        else if(!HaveATarget)
        {
            if (BarricadeController.Instance.BarricadeHealth > 0)
                CurrentTarget = BarricadeController.Instance.BarricadeGameObject.transform;
            else if (PlayerInfo.instance.CharacterHealthAmount > 0)
                CurrentTarget = PlayerInfo.instance.PlayerObject.transform;

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

}
