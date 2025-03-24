using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Return()
    {
        SceneManager.LoadScene("MenuMain");
    }
}
