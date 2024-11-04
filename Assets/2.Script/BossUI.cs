using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public static BossUI Instance;

    public float BossHp = 10000f;
    public DataManager DataManager;
    public FadeManager fadeMAnager;
    private bool Siu = true;

    [Header("피통")]
    public Image PlayerHpImg;
    public float HpCount = 20f;
    public float MaxPlayerHp = 1000f;
    public float HpPlus = 100;

    [Header("자동차함정")]
    public GameObject PoliceCar;
    public Slider BossHpSlider;

    [Header("랜덤박스")]
    public Image TargetImg;

    [Header("상점")]
    public GameObject StoreUi;
    public Image TarImg;
    public Image TarImg1;
    public Image TarImg2;
    public Button AButton;
    public Button BButton;
    public Button CButton;
    public Sprite[] gage;
    public AudioSource[] audioSources;
    private bool Stageing = true;



    private void Awake()
    {
        DataManager.Init();
        Time.timeScale = 1;
        Instance = this;
        StartCoroutine(TimerSet());
    }

    void Update()
    {
        BossHpSlider.value = BossHp;
        PlayerHpImg.fillAmount = DataManager.Instance.PlayerHp / 1000;

        if (BossHp <= 5000)
        {
            PoliceCar.SetActive(true);
            CarManager.Instance.DeactivateAndRemoveItems();
        }
        else if (DataManager.Instance.PlayerHp >= DataManager.Instance.MaxPlayerHp)
        {
            DataManager.Instance.PlayerHp = DataManager.Instance.MaxPlayerHp;
        }

        if (BossHp <= 0)
        {
            if (Siu)
            {
                StoreUi.SetActive(true);
                Siu = false;
            }
        }
        else if (DataManager.Instance.PlayerHp <= 1)
        {
            if (Siu)
            {
                DataManager.Instance.StageIndex = 0;
                fadeMAnager.FadeOutAndIn();
                Siu = false;
            }
        }


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
            DataManager.Instance.PlayerHp -= HpCount;
            yield return new WaitForSeconds(1f);
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

    public void NextStage()
    {
        if (Stageing)
        {
            DataManager.Instance.StageIndex += 1;
            FadeManager.Instance.FadeOutAndIn();
            Stageing = false;
        }
    }
}

