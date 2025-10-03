using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [Header("Melee prefab")]
    public GameObject MeleeWeaponPrefab;
    [Header("Range prefab")]
    public GameObject RangeWeaponPrefab;
    [Header("Booleans")]
    public bool HasWeaponActive = false;

    ShieldController _shieldController;
    PlayerMovement _playerMovement;

    private void Start()
    {
        _shieldController = GetComponent<ShieldController>();
        _playerMovement = GetComponent<PlayerMovement>();   
        SwitchToMelee();
    }

    private void Update()
    {
        if (HasWeaponActive == false)
            SwitchToMelee();
        if (_shieldController.IsShieldActive)
            DisableAllWeapons();
        else
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                SwitchToMelee();
                _playerMovement.TurnOffStopPlayerMovement();    
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                _playerMovement.TurnOnStopPlayerMovement(); 
                SwitchToRange();
            }
        }
    }

    void SwitchToMelee()
    {
        HasWeaponActive = true;
        MeleeWeaponPrefab.SetActive(true);
        RangeWeaponPrefab.SetActive(false);
        Debug.Log("switched to melee");
    }

    void SwitchToRange()
    {
        HasWeaponActive = true;
        RangeWeaponPrefab.SetActive(true);
        MeleeWeaponPrefab.SetActive(false);
        Debug.Log("switch to range");
    }
    void DisableAllWeapons()
    {
        HasWeaponActive = false;
        RangeWeaponPrefab.SetActive(false);
        MeleeWeaponPrefab.SetActive(false);
    }

}
