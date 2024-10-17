using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public GameObject ShopUi;
    public GameObject carManager;
    public DataManager dataManager;

    [Header("피통")]
    public Slider PlayerHpSlider;
    public float HpCount = 10f;
    public float HpPlus = 100;

    [Header("맵")]
    public Slider MapSlider;
    public float Timer;

    [Header("코인")]
    public Text cointxt;
    public Text cointxt1;

    [Header("상점")]
    public float SpeedPlus = 5;
    public int StoreIndex;
    public Image TarImg;
    public Sprite[] gage;

    [Header("랜덤박스")]
    public Image TargetImg;
    public Sprite[] newsprite;
    public GameObject randombox;
    public AudioSource[] audioSources;

    private void Start()
    {
        Instance = this;
        dataManager.Init();
        DataManager.Instance.PlayerHp = 1000f;
        DataManager.Instance.Coin = 0;
        StartCoroutine(TimerSet());
    }


    void Update()
    {
        PlayerHpSlider.value = DataManager.Instance.PlayerHp;
        MapSlider.value = Timer;

        if (Timer == 50)
        {
            randombox.SetActive(true);
        }

        if (Timer >= 60)
        {
            ShopUi.SetActive(true);
            Timer = 75;
            HpCount = 0;
            carManager.SetActive(false);
            Time.timeScale = 0;
        }

        //랜덤박스

        // 코인
        cointxt.text = DataManager.Instance.Coin.ToString();
        cointxt1.text = DataManager.Instance.Coin.ToString();

        //피
        if (DataManager.Instance.PlayerHp <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
        else if (DataManager.Instance.PlayerHp >= DataManager.Instance.MaxPlayerHp)
        {
            DataManager.Instance.PlayerHp = DataManager.Instance.MaxPlayerHp;
        }

        //랜덤박스
        if (DataManager.Instance.SkillIndex == 6)
        {
            TargetImg.sprite = newsprite[5];
        }

        switch (StoreIndex)
        {
            case 0:
                TargetImg.sprite = gage[0];
                break;

            case 1:
                TargetImg.sprite = gage[1];
                break;

            case 2:
                TargetImg.sprite = gage[2];
                break;

            case 3:
                TargetImg.sprite = gage[3];
                break;
        }
    }


    public IEnumerator TimerSet()
    {
        while (true)
        {
            Timer += 1;

            DataManager.Instance.PlayerHp -= HpCount;

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

    public void BossGo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Boss");

    }

    public void Agoods()
    {
        if (DataManager.Instance.Coin >= 20f)
        {
            DataManager.Instance.Coin -= 20f;
            DataManager.Instance.PlayerHp = DataManager.Instance.MaxPlayerHp;
            audioSources[0].Play();
        }
    }
    public void Bgoods()
    {
        if (DataManager.Instance.Coin >= 20f)
        {
            DataManager.Instance.Coin -= 20f;
            DataManager.Instance.BulletIndex += 1;
            DataManager.Instance.PlayerPower += SpeedPlus;
            audioSources[0].Play();
        }
    }
    public void Cgoods()
    {
        if (DataManager.Instance.Coin >= 20f)
        {
            DataManager.Instance.Coin -= 20f;
            DataManager.Instance.PlayerSpeed += SpeedPlus;
            audioSources[0].Play();
        }
    }
    public void GameExit()
    {
        Application.Quit();
    }



}
