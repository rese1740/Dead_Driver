using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{

   public DataManager dataManager;
    private void Start()
    {
       dataManager.Init();
    }

    private void Update()
    {
         
    }
    public void GoStart()
    {
        SceneManager.LoadScene("Main");
        DataManager.Instance.PlayerHp = 1000f;
        DataManager.Instance.Coin = 0;
        DataManager.Instance.PlayerPower = 10;
        DataManager.Instance.PlayerSpeed = 10;
        DataManager.Instance.BulletIndex = 0;
        DataManager.Instance.StageIndex = 1;
        DataManager.Instance.StoreIndex = 0;
        DataManager.Instance.StoreIndex1 = 0;
        DataManager.Instance.StoreIndex2 = 0;
        DataManager.Instance.BulletIndex = 0;
    }

    public void GoExit()
    {
       Application.Quit();
    }
}
