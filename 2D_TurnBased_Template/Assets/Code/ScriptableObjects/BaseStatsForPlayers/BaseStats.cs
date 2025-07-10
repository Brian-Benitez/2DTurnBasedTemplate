using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Base Stats")]
public class BaseStats : ScriptableObject
{
    public string Name;
    public int Health;
    public int MaxHealth;
    public int Sanity;
    public int Level;

    public void PrintInfo()
    {
        Debug.Log("Name: " +  Name + " Health: " + Health + " Sanity: " + Sanity);
    }
}
