using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    int count = 0;
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
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
    public void Quit()
    {
        SceneManager.LoadScene("Quit");
    }
    public void ExtraQuit()
    {
        SceneManager.LoadScene("QuitExtra");
    }
    public void Fine()
    {
        Application.Quit();
    }
    public void No()
    {
        SceneManager.LoadScene("MenuMain");
    }
    public void previous()
    {
        count--;
    }
    public void next()
    {
        count++;
    }
    public void CreditScreen()
    {
        if (count == 0)
        {
            count = 1;
        }
        if (count == 1)
        {
            SceneManager.LoadScene("Abigail");
        }
        if (count == 2)
        {
            SceneManager.LoadScene("Delsin");
        }
        if (count == 3)
        {
            SceneManager.LoadScene("Thomas");
        }
        if (count == 4)
        {
            count = 1;
        }
    }
}