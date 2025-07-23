using DG.Tweening;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [Header("Name")]
    public string NameOfCharacter;
    [Header("Health")]
    public int CharacterHealthAmount;
    public int CharacterMaxHealthLevel;
    [Header("Damage")]
    public int CharacterDamageOutput;
    [Header("Sanity")]
    public int CharacterSanityAmount;
    public int CharacterMaxSanityLevel;

    public void PrintInfo()
    {
        Debug.Log("Name: " + NameOfCharacter + " Max health:" + CharacterMaxHealthLevel + " Max Sainty: " + CharacterMaxSanityLevel);
    }

    public void TakeDamage(int damage)
    {
        CharacterHealthAmount -= damage;
        Debug.Log(NameOfCharacter + " took: " + damage);
        DoesCharacterDie();
    }

    public void DoesCharacterDie()
    {
        if (CharacterHealthAmount < 0)
        {
            this.gameObject.gameObject.SetActive(false);
        }
        else
            Debug.Log(NameOfCharacter + " Still has health");
    }

    public void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }

}
