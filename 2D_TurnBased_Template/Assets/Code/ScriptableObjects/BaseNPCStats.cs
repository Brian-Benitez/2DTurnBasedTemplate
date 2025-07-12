using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "Base NPC Stats")]
public class BaseNPCStats : ScriptableObject
{
    public string NameOfNPC;

    public int NPCHealthAmount;
    public int NPCMaxHealthLevel;

    public int NPCSanityAmount;
    public int NPCMaxSanityLevel;

    public void PrintInfo()
    {
        Debug.Log("Name: " +  NameOfNPC + " Max health:" + NPCMaxHealthLevel + " Max Sainty: " + NPCMaxSanityLevel);
    }
}
