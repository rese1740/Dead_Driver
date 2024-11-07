using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataManager : ScriptableObject
{
    public static DataManager Instance;

    [Header("�÷��̾�")]
    public float PlayerHp;
    public float MaxPlayerHp = 1f;
    public float HpCount = 0.01f;
    public float PlayerSpeed;
    public float PlayerPower;
    public float HpPlus = 0.5f;


    [Header("����")]
    public float Coin = 0;
    public float CoinPlus = 50;
     
    [Header("�����ڽ�")]
    public int SkillIndex;
    public Sprite[] newsprite;

    [Header("��")]
    public int BulletIndex;
    public Sprite[] BulletSprite;


    [Header("�Ҹ�")]
    public int AudioIndex;

    [Header("����")]
    public float SpeedPlus = 2;
    public float PowerPlus = 10;
    public int StoreIndex;
    public int StoreIndex1;
    public int StoreIndex2;
    public float Aprice;
    public float Bprice;
    public Color newColor;
    public Sprite[] gage;

    [Header("��������")]
    public int StageIndex;
    public int EndingIndex;
    public bool Stagebool = true;




    public void Init()
    {
        Instance = this;
    }
}
