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

    [Header("피통")]
    public Image PlayerHpImg;
    [Header("맵")]
    public Slider MapSlider;
    public float Timer;
    public float StageEnd;
    public bool Sex;

    [Header("코인")]
    public Text cointxt;
    public Text cointxt1;

    [Header("랜덤박스")]
    public Image TargetImg;
    public GameObject randombox;
    public AudioSource[] audioSources;


    [Header("상점")]
    public GameObject StoreUi;
    public Image TarImg;
    public Image TarImg2;
    public Button AButton;
    public Button BButton;
    public Button CButton;
    public Text AText;
    public Text BText;
    public Sprite[] gage;
    private bool Stageing = true;


    private void Start()
    {
        Time.timeScale = 1;
        Instance = this;
        dataManager.Init();
        StartCoroutine(TimerSet());
    }


    void Update()
    {
        PlayerHpImg.fillAmount = DataManager.Instance.PlayerHp /DataManager.Instance.MaxPlayerHp;
        MapSlider.value = Timer;


        if (Timer >= StageEnd)
        {
            Timer = 75;
            if (Sex)
            {
               StoreUi.SetActive(true);
                Time.timeScale = 0;
                Sex = false;
            }
        }

        //랜덤박스

        // 코인
        cointxt.text = DataManager.Instance.Coin.ToString();
        cointxt1.text = DataManager.Instance.Coin.ToString();

        // 상점 가격
        AText.text = DataManager.Instance.Aprice.ToString();
        BText.text = DataManager.Instance.Bprice.ToString();

        //피
        if (DataManager.Instance.PlayerHp <= 0)
        {
            if (Stageing)
            {
                DataManager.Instance.EndingIndex = DataManager.Instance.StageIndex;
                FadeManager.Instance.FadeOutAndIn();
                Stageing = false;
                DataManager.Instance.StageIndex = 0;
            }
        }
        else if (DataManager.Instance.PlayerHp >= DataManager.Instance.MaxPlayerHp)
        {
            DataManager.Instance.PlayerHp = DataManager.Instance.MaxPlayerHp;
        }


        //코인
        if(DataManager.Instance.Coin <= 0)
        {
            DataManager.Instance.Coin = 0;
        }

        //랜덤박스
        switch (DataManager.Instance.SkillIndex)
        {
            case 1:
                TargetImg.sprite = DataManager.Instance.newsprite[0];
                break;

            case 2:
                TargetImg.sprite = DataManager.Instance.newsprite[1];
                break;

            case 3:
                TargetImg.sprite = DataManager.Instance.newsprite[2];
                break;

            case 4:
                TargetImg.sprite = DataManager.Instance.newsprite[3];
                break;

            case 5:
                TargetImg.sprite = DataManager.Instance.newsprite[4];
                break;
        }


        //B
        switch (DataManager.Instance.StoreIndex)
        {
            case 0:
                TarImg.sprite = gage[0];
                break;

            case 1:
                TarImg.sprite = gage[1];
                break;

            case 2:
                TarImg.sprite = gage[2];
                break;

            case 3:
                TarImg.sprite = gage[3];
                TarImg.color = DataManager.Instance.newColor;
                BButton.interactable = false;
                break;
        }

        // C

        //A
        switch (DataManager.Instance.StoreIndex2)
        {
            case 0:
                TarImg2.sprite = gage[0];
                break;

            case 1:
                TarImg2.sprite = gage[1];
                break;

            case 2:
                TarImg2.sprite = gage[2];
                break;

            case 3:
                TarImg2.sprite = gage[3];
                TarImg2.color = DataManager.Instance.newColor;
                AButton.interactable = false;
                break;
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

    

    public void Agoods()
    {
        if (DataManager.Instance.Coin >= DataManager.Instance.Aprice)
        {
            DataManager.Instance.Coin -= DataManager.Instance.Aprice;
            DataManager.Instance.Aprice += 10;
            DataManager.Instance.StoreIndex2 += 1;
            DataManager.Instance.MaxPlayerHp += 200;
            audioSources[0].Play();
        }
    }
    public void Bgoods()
    {
        if (DataManager.Instance.Coin >= DataManager.Instance.Bprice)
        {
            DataManager.Instance.Coin -= DataManager.Instance.Bprice;
            DataManager.Instance.Bprice += 5;
            DataManager.Instance.StoreIndex += 1;
            DataManager.Instance.BulletIndex += 1;
            DataManager.Instance.PlayerPower += DataManager.Instance.PowerPlus;
            audioSources[0].Play();
        }
    }
    public void Cgoods()
    {
        if (DataManager.Instance.Coin >= 10f)
        {
            DataManager.Instance.Coin -= 10f;
            DataManager.Instance.StoreIndex1 += 1;
           DataManager.Instance.PlayerHp = DataManager.Instance.MaxPlayerHp;
            audioSources[0].Play();
        }
    }

    public void NextStage()
    {
        if (Stageing)
        {
            Time.timeScale = 1;
            DataManager.Instance.StageIndex += 1;
            FadeManager.Instance.FadeOutAndIn();
            Stageing = false;
        }
    }



    public void GameExit()
    {
        Application.Quit();
    }



}
