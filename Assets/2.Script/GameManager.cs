using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BossUI.Instance.BossHp == 0)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
