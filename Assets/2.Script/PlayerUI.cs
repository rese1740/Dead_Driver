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
    public FadeManager fadeManager;

    [Header("피통")]
    public Image PlayerHpImg;
    [Header("맵")]
    public Slider MapSlider;
    public float Timer;

    [Header("코인")]
    public Text cointxt;
    public Text cointxt1;

    [Header("상점")]
    public Image TarImg;
    public Image TarImg1;
    public Image TarImg2;
    public Button AButton;
    public Button BButton;
    public Button CButton;
    public Sprite[] gage;
    public float StageEnd;
    public bool Sex;

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
        PlayerHpImg.fillAmount = DataManager.Instance.MaxPlayerHp;
        DataManager.Instance.Coin = 0;
        DataManager.Instance.PlayerPower = 10;
        DataManager.Instance.PlayerSpeed = 10;
        DataManager.Instance.BulletIndex = 0;
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

        switch (DataManager.Instance.StoreIndex1)
        {
            case 0:
                TarImg1.sprite = gage[0];
                break;

            case 1:
                TarImg1.sprite = gage[1];
                break;

            case 2:
                TarImg1.sprite = gage[2];
                break;

            case 3:
                TarImg1.color = DataManager.Instance.newColor;
                TarImg1.sprite = gage[3];
                CButton.interactable = false;
                break;
        }

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


    public void Agoods()
    {
        if (DataManager.Instance.Coin >= 20f)
        {
            DataManager.Instance.Coin -= 20f;
            DataManager.Instance.StoreIndex2 += 1;
            DataManager.Instance.MaxPlayerHp += 200;
            audioSources[0].Play();
        }
    }
    public void Bgoods()
    {
        if (DataManager.Instance.Coin >= 20f)
        {
            DataManager.Instance.Coin -= 20f;
            DataManager.Instance.StoreIndex += 1;
            DataManager.Instance.BulletIndex += 1;
            DataManager.Instance.PlayerPower += DataManager.Instance.PowerPlus;
            audioSources[0].Play();
        }
    }
    public void Cgoods()
    {
        if (DataManager.Instance.Coin >= 20f)
        {
            DataManager.Instance.Coin -= 20f;
            DataManager.Instance.StoreIndex1 += 1;
            DataManager.Instance.PlayerSpeed += DataManager.Instance.SpeedPlus;
            audioSources[0].Play();
        }
    }
    public void GameExit()
    {
        Application.Quit();
    }



}
