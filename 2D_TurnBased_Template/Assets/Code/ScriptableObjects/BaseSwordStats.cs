using UnityEngine;

[CreateAssetMenu(fileName = "New Sword", menuName = "Base Sword Stats")]
public class BaseSwordStats : ScriptableObject
{
    public string SwordName;

    public int SwordDamage;

    [SerializeField]
    public enum Buffs {PlusSpeed, DoubleDamage};
    [SerializeField]
    public enum Debuffs {LowHealth, SlowSwing};

    [Header("Buffs and debuff")]
    public Buffs SwordBuff;
    public Debuffs SwordDebuff;
}
