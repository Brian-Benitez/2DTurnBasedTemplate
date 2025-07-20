using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public string NameOfCharacter;

    public int CharacterHealthAmount;
    public int CharacterMaxHealthLevel;

    public int CharacterDamageOutput;

    public int CharacterSanityAmount;
    public int CharacterMaxSanityLevel;

    public void PrintInfo()
    {
        Debug.Log("Name: " + NameOfCharacter + " Max health:" + CharacterMaxHealthLevel + " Max Sainty: " + CharacterMaxSanityLevel);
    }

}
