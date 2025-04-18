using UnityEngine;
public class ResetPos : MonoBehaviour
{
    public KeyCode reset;
    void Update()
    {
        if (Input.GetKeyDown(reset))
        {
            transform.position = new Vector3(0, 5, 0);
        }
    }
}