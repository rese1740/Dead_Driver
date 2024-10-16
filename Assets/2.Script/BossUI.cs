using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public static BossUI Instance;

    public float BossHp = 10000f;
    public DataManager DataManager;
    public GameObject fadeMAnager;

    [Header("피통")]
    public Slider PlayerHpSlider;
    public float HpCount = 10f;
    public float PlayerHp_B = 1000f;
    public float MaxPlayerHp = 1000f;
    public float HpPlus = 100;

    [Header("자동차함정")]
    public GameObject PoliceCar;

    public Slider BossHpSlider;


    private void Awake()
    {
        DataManager.Init();
        Instance = this;
        StartCoroutine(TimerSet());
    }

    void Update()
    {
        PlayerHp_B = DataManager.Instance.PlayerHp;
        BossHpSlider.value = BossHp;
        PlayerHpSlider.value = PlayerHp_B;

        if (BossHp <= 5000)
        {
            PoliceCar.SetActive(true);
            CarManager.Instance.isActivated = false;
        }
        else if (BossHp <= 0)
        {
            fadeMAnager.SetActive(true);
        }
        else if (PlayerHp_B <= 1)
        {
            fadeMAnager.SetActive(true);
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

