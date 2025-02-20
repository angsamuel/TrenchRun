using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Ship ship;
    void Update()
    {
        float movement = 0;
        if(Input.GetKey(KeyCode.A)) {
            movement -= 1;
        }
        if(Input.GetKey(KeyCode.D)) {
            movement += 1;
        }
        ship.Move(movement);
    }
}
