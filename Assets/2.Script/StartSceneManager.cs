using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void GoStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoExit()
    {
        SceneManager.LoadScene("Exit");
    }
}
