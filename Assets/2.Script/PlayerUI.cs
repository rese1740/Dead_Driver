using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public GameObject ShopUi;
    public GameObject randomBox;
    public GameObject carManager;

    [Header("피통")]
    public Slider PlayerHpSlider;
    public float HpCount = 10f;
    public float PlayerHp = 1000f;
    public float MaxPlayerHp = 1000f;
    public float HpPlus = 100;

    [Header("맵")]
    public Slider MapSlider;
    public float Timer;

    [Header("코인")]
    public Text cointxt;
    public float Coin;
    public float CoinPlus = 50;

    [Header("상점")]
    public float SpeedPlus = 5;

    [Header("랜덤박스")]
    public Image TargetImg;
    public Sprite[] newsprite;
    public float SkillIndex = 0;

    private void Start()
    {
        Instance = this;
        StartCoroutine(TimerSet());
    }


    void Update()
    {
        PlayerHpSlider.value = PlayerHp;
        MapSlider.value = Timer;

        if (Timer == 50)
        {

        }

        if (Timer >= 60)
        {
            ShopUi.SetActive(true);
            Timer = 75;
            HpCount = 0;
            carManager.SetActive(false);
        }

        //랜덤박스

        // 코인
        cointxt.text = Coin.ToString();

        //피
        if (PlayerHp <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
        else if (PlayerHp >= MaxPlayerHp)
        {
            PlayerHp = MaxPlayerHp;
        }
    }


    public IEnumerator TimerSet()
    {
        while (true)
        {
            Timer += 1;

            PlayerHp -= HpCount;

            yield return new WaitForSeconds(1f);

        }
    }

    public void RandomBoxManager()
    {
        int randomBoxIndex = Random.Range(0, 5);
        switch (randomBoxIndex)
        {
            case 0:
                TargetImg.sprite = newsprite[0];
                SkillIndex = 1;
                break;

            case 1:
                TargetImg.sprite = newsprite[1];
                SkillIndex = 2;
                break;

            case 2:
                TargetImg.sprite = newsprite[2];
                SkillIndex = 3;
                break;

            case 3:
                TargetImg.sprite = newsprite[3];
                SkillIndex = 4;
                break;

            case 4:
                TargetImg.sprite = newsprite[4];
                SkillIndex = 5;
                break;
        }
    }

    public void BossGo()
    {
        PlayerPrefs.SetFloat("PlayerHp", PlayerHp);
        SceneManager.LoadScene("Boss");
    }

    public void Agoods()
    {
        PlayerHp = MaxPlayerHp;
    }
    public void Bgoods()
    {

    }
    public void Cgoods()
    {
        Taxi.Instance.moveSpeed += SpeedPlus;
    }
    public void GameExit()
    {
        Application.Quit();
    }



}
