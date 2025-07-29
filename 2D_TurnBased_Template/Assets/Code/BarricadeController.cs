using UnityEngine;

public class BarricadeController : MonoBehaviour
{
    public static BarricadeController Instance { get; private set; }

    public int BarricadeHealth;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void BarricadeTakesDamage(int damage)
    {
        BarricadeHealth -= damage;
        Debug.Log("barricade took damage!");
    }

    public void BarricadeHealsHealth(int heals)
    {
        BarricadeHealth += heals;
        Debug.Log("barricade heals for: " +  heals);    
    }
}
