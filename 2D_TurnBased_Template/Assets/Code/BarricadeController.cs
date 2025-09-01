
using System.Collections.Generic;
using UnityEngine;

public class BarricadeController : MonoBehaviour
{
    public static BarricadeController Instance { get; private set; }
    [Header("Barricade Health")]
    public int BarricadeHealth;

    [Header("Barricade Game Object")]
    public GameObject BarricadeGameObject;

    public bool BarricadeEnabled = true;
    public bool CanAttackBarricade = true;

    [Header("Attack Points")]
    public List<GameObject> AttackPointsLocation;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void BarricadeTakesDamage(int damage)
    {
        BarricadeHealth -= damage;
        Debug.Log("barricade took: " + damage + " damage!");
        CheckBarricadeHealth();
    }

    public void BarricadeHealsHealth(int heals)
    {
        BarricadeHealth += heals;
        Debug.Log("barricade heals for: " +  heals);    
        CheckBarricadeHealth() ;
    }

    private void CheckBarricadeHealth()
    {
        if(BarricadeHealth <= 0)
        {
            BarricadeGameObject.SetActive(false);
            BarricadeEnabled = false;
        }
        else
        { 
            BarricadeGameObject.SetActive(true);
            BarricadeEnabled = true;
        }
    }
}
