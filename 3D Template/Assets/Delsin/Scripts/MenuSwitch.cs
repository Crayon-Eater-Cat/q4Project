using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    int count = 0;
    KeyCode up, down, upAlt, downAlt;
    public void SwitchSettings()
    {
        if (Input.GetKeyDown(up) || Input.GetKeyDown(upAlt))
        {
            count++;
        }
        if (Input.GetKeyDown(down) || Input.GetKeyDown(downAlt))
        {
            count--;
        }

    }
}
