using JetBrains.Annotations;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

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