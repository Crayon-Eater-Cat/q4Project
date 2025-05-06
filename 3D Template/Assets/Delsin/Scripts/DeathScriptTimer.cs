using System.Threading;
using UnityEngine;

public class DeathScriptTimer : MonoBehaviour
{
    private float inClock;
    public GameObject FirstTxt;
    public GameObject SecondTxt;
    public GameObject LastTxt;
    public void Update()
    {
        SecondTxt.SetActive(false);
        LastTxt.SetActive(false);
        inClock += Time.deltaTime;
        if (inClock >= 2.99)
        {
            FirstTxt.SetActive(false);
            SecondTxt.SetActive(true);
        }
        if (inClock >= 5.99)
        {
            SecondTxt.SetActive(false);
            LastTxt.SetActive(true);
        }
        Debug.Log(inClock);
    }
}
