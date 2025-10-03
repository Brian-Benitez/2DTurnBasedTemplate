using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    public GameObject PlayerObject;

    public bool StopPlayerMovement = false;

    private void Update()
    {
        if(StopPlayerMovement)
            return;
        else
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(x, y, 0);
            tempVect = tempVect.normalized * PlayerSpeed * Time.deltaTime;

            PlayerObject.transform.position += tempVect;
        }
    }

    public void TurnOnStopPlayerMovement() => StopPlayerMovement = true;

    public void TurnOffStopPlayerMovement() => StopPlayerMovement = false;
}
