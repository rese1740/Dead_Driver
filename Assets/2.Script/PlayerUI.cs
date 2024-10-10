using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public float PlayerHp = 1000f;
    public float Timer;
    public float HpCount = 10f;

    public GameObject ShopUi;
    public GameObject randomBox;
    public GameObject carManager;


    public Slider PlayerHpSlider;
    public Slider MapSlider;


    [Header("코인")]
    public Text cointxt;
    public float Coin;

    private void Start()
    {
        Instance = this;
        StartCoroutine(TimerSet());
    }


    void Update()
    {
        PlayerHpSlider.value = PlayerHp;
        MapSlider.value = Timer;

        if (Timer == 65)
        {
           
        }

        if (Timer >= 75)
        {
            ShopUi.SetActive(true);
            Timer = 75;
            HpCount = 0;
            carManager.SetActive(false);


        }


        //랜덤박스


        // 코인
        cointxt.text = Coin.ToString();

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
    public void BossGo()
    {
        SceneManager.LoadScene("Boss");
    }


}
