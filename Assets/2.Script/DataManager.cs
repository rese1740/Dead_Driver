using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataManager : ScriptableObject
{
    public static DataManager Instance;

    [Header("플레이어")]
    public float PlayerHp;
    public float MaxPlayerHp = 1f;
    public float HpCount = 0.01f;
    public float PlayerSpeed;
    public float PlayerPower;
    public float HpPlus = 0.5f;


    [Header("코인")]
    public float Coin = 0;
    public float CoinPlus = 50;
     
    [Header("랜덤박스")]
    public int SkillIndex;
    public Sprite[] newsprite;

    [Header("총")]
    public int BulletIndex;
    public Sprite[] BulletSprite;


    [Header("소리")]
    public int AudioIndex;

    [Header("상점")]
    public float SpeedPlus = 2;
    public float PowerPlus = 10;
    public int StoreIndex;
    public int StoreIndex1;
    public int StoreIndex2;
    public float Aprice;
    public float Bprice;
    public Color newColor;
    public Sprite[] gage;

    [Header("스테이지")]
    public int StageIndex;
    public int EndingIndex;
    public bool Stagebool = true;




    public void Init()
    {
        Instance = this;
    }
}
