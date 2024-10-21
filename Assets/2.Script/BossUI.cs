using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public static BossUI Instance;

    public float BossHp = 10000f;
    public DataManager DataManager;
    public FadeManager fadeMAnager;

    [Header("피통")]
    public Slider PlayerHpSlider;
    public float HpCount = 20f;
    public float PlayerHp_B = 1000f;
    public float MaxPlayerHp = 1000f;
    public float HpPlus = 100;

    [Header("자동차함정")]
    public GameObject PoliceCar;
    public bool FadeIndex = true;

    public Slider BossHpSlider;

    [Header("랜덤박스")]
    public Image TargetImg;


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
        PlayerHpSlider.value = DataManager.Instance.PlayerHp;

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
            FadeIndex = true;
            fadeMAnager.FadeOutAndIn();
            DataManager.Instance.AudioIndex += 1;
        }
        else if (DataManager.Instance.PlayerHp <= 1)
        {
            FadeIndex = false;
            fadeMAnager.FadeOutAndIn();
        }

         switch (DataManager.Instance.SkillIndex)
        {
            case 1:
                TargetImg.sprite = DataManager.Instance.newsprite[0];
                break;

            case 2:
                TargetImg.sprite =  DataManager.Instance.newsprite[1];
                break;

            case 3:
                TargetImg.sprite =  DataManager.Instance.newsprite[2];
                break;

            case 4:
                TargetImg.sprite = DataManager.Instance.newsprite[3];
                break;

            case 5:
                TargetImg.sprite =  DataManager.Instance.newsprite[4];
                break;

        }
    }

    public IEnumerator TimerSet()
    {
        while (true)
        {
            PlayerHp_B -= HpCount;
            yield return new WaitForSeconds(1f);
        }

    }
}

