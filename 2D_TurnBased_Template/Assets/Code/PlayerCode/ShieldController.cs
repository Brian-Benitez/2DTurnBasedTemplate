using UnityEngine;
using UnityEngine.Rendering;

public class ShieldController : MonoBehaviour
{
    [Header("Shield Object")]
    public GameObject ShieldObject;

    [Header("Booleans")]
    public bool IsShieldActive = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ShieldObject.SetActive(true);
            TurnOnShieldObject();
        }
        else
        {
            ShieldObject.SetActive(false);
            TurnOffIsShieldActive();
        }
            
    }

    void TurnOnShieldObject() => IsShieldActive = true;
    void TurnOffIsShieldActive() => IsShieldActive = false;
}
