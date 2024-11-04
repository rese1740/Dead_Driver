using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public GameObject carManager;
    public DataManager dataManager;
    public FadeManager fadeManager;

    [Header("ÇÇÅë")]
    public Image PlayerHpImg;
    [Header("¸Ê")]
    public Slider MapSlider;
    public float Timer;
    public float StageEnd;
    public bool Sex;

    [Header("ÄÚÀÎ")]
    public Text cointxt;

    [Header("·£´ý¹Ú½º")]
    public Image TargetImg;
    public Sprite[] newsprite;
    public GameObject randombox;
    public AudioSource[] audioSources;
    

    private void Start()
    {
        Time.timeScale = 1;
        Instance = this;
        dataManager.Init();
        StartCoroutine(TimerSet());
    }


    void Update()
    {
        PlayerHpImg.fillAmount = DataManager.Instance.PlayerHp / DataManager.Instance.MaxPlayerHp;
        MapSlider.value = Timer;


        if (Timer >= StageEnd)
        {
            Timer = 75;
            if (Sex)
            {
                DataManager.Instance.StageIndex += 1;
                fadeManager.FadeOutAndIn();
                Sex = false;
            }
        }

        //·£´ý¹Ú½º

        // ÄÚÀÎ
        cointxt.text = DataManager.Instance.Coin.ToString();

        //ÇÇ
        if (DataManager.Instance.PlayerHp <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
        else if (DataManager.Instance.PlayerHp >= DataManager.Instance.MaxPlayerHp)
        {
            Debug.Log(1);
            DataManager.Instance.PlayerHp = DataManager.Instance.MaxPlayerHp;
        }

        //·£´ý¹Ú½º
        if (DataManager.Instance.SkillIndex == 6)
        {
            TargetImg.sprite = newsprite[5];
        }

      
    }


    public IEnumerator TimerSet()
    {
        while (true)
        {
            Timer += 1;

            DataManager.Instance.PlayerHp -= DataManager.Instance.HpCount;

            yield return new WaitForSeconds(1f);

        }
    }

    public void RandomBoxManager()
    {
        int randomBoxIndex = Random.Range(0, 5);
        switch (randomBoxIndex)
        {
            case 0:
                TargetImg.sprite = DataManager.Instance.newsprite[0];
                DataManager.Instance.SkillIndex = 1;
                break;

            case 1:
                TargetImg.sprite = DataManager.Instance.newsprite[1];
                DataManager.Instance.SkillIndex = 2;
                break;

            case 2:
                TargetImg.sprite = DataManager.Instance.newsprite[2];
                DataManager.Instance.SkillIndex = 3;
                break;

            case 3:
                TargetImg.sprite = DataManager.Instance.newsprite[3];
                DataManager.Instance.SkillIndex = 4;
                break;

            case 4:
                TargetImg.sprite = DataManager.Instance.newsprite[4];
                DataManager.Instance.SkillIndex = 5;
                break;

        }
    }


    
    public void GameExit()
    {
        Application.Quit();
    }



}
