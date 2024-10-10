using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public static BossUI Instance;

    public float BossHp = 10000f;


    [Header("자동차함정")]
    public GameObject PoliceCar;

    public Slider BossHpSlider;

    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        BossHpSlider.value = BossHp;


        if(BossHp <= 5000 ) 
        {
          PoliceCar.SetActive(true);
        }
    }
}
