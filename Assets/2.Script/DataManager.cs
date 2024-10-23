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
    public float HpPlus = 200f;

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



    public void Init()
    {
        Instance = this;
    }
}
