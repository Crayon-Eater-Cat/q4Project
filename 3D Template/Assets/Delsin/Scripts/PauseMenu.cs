using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pause;
    private int toggle;
    public GameObject pauseMenu;
    public void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            toggle++;
            Debug.Log(toggle);
        }
        if (toggle == 1)
        {
            Debug.Log("Paused");
            pauseMenu.SetActive(true);
        }
        if (toggle >= 2)
        {
            Debug.Log("Resume");
            pauseMenu.SetActive(false);
            toggle = 0;
        }
    }
}