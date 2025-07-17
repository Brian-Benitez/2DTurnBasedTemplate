using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [Header("Melee prefab")]
    public GameObject MeleeWeaponPrefab;
    [Header("Range prefab")]
    public GameObject RangeWeaponPrefab;

    private void Start() => SwitchToMelee();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            SwitchToMelee();
        else if(Input.GetKeyUp(KeyCode.Alpha2))
            SwitchToRange();
    }

    void SwitchToMelee()
    {
        MeleeWeaponPrefab.SetActive(true);
        RangeWeaponPrefab.SetActive(false);
        Debug.Log("switched to melee");
    }

    void SwitchToRange()
    {
        RangeWeaponPrefab.SetActive(true);
        MeleeWeaponPrefab.SetActive(false);
        Debug.Log("switch to range");
    }
    void DisableAllWeapons()
    {
        RangeWeaponPrefab.SetActive(false);
        MeleeWeaponPrefab.SetActive(false);
    }

}
