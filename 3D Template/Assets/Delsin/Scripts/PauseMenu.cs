using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pause;
    private int toggle;
    public GameObject pauseMenu;
    //public GameObject resumeButton;
    public void Start()
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
            Debug.Log("Paused : " + toggle);
            pauseMenu.SetActive(true);
        }
        if (toggle >= 2)
        {
            Debug.Log("Resume : " + toggle);
            pauseMenu.SetActive(false);
            toggle = 0;
            Debug.Log(toggle);
        }
    }
    public void Resume()
    {
        toggle++;
        pauseMenu.SetActive(false);
        Debug.Log("Resume");
    }
}