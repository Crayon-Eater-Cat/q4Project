using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Animator SceneTransition;

    private void Start()
    {
        DontDestroyOnLoad(SceneTransition.transform.parent.gameObject);
    }

    public void ChangeScenes(string SceneName)
    {
        StartCoroutine(loadASync(SceneName));
    }

    IEnumerator loadASync(string SceneName)
    {
        var operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        SceneTransition.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        SceneTransition.SetTrigger("Finished");
        
        operation.allowSceneActivation = true;
    }
    int count = 0;
    public GameObject[] Images;
    public void Play()
    {
        SceneManager.LoadScene("Nelson");
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
        Images[count].gameObject.SetActive(false);
        count -= 1;
        if (count == -1)
        {
            count = Images.Length - 1;
            print("Going back");
        }
        print("Previous one:" + count);
        //CreditScreen();
        Images[count].gameObject.SetActive(true);
    }
    public void next()
    {
        Images[count].gameObject.SetActive(false);
        count += 1;
        if (count == Images.Length)
        {
            count = 0;
            print("Going back");
        }
        print("Next one:" + count);
        //CreditScreen();
        Images[count].gameObject.SetActive(true);
    }
    public GameObject activeGameObject;

    public void ActiveObject(GameObject GO)
    {
        if (GO.activeSelf!= true)
        {
            GO.SetActive(true);
        }
    }
    //public void CreditScreen()
    //{
    //    if (count <= -1)
    //    {
    //        count = 3;
    //    }
    //    if (count == 0)
    //    {
    //        SceneManager.LoadScene("Credits");
    //    }
    //    if (count == 1)
    //    {
    //        SceneManager.LoadScene("Abigail");
    //    }
    //    if (count == 2)
    //    {
    //        SceneManager.LoadScene("Delsin");
    //    }
    //    if (count == 3)
    //    {
    //        SceneManager.LoadScene("Thomas");
    //    }
    //    if (count == 4)
    //    {
    //        count = 0;
    //        print("Going back");
    //    }
    //}
}