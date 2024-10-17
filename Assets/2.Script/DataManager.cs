using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataManager : ScriptableObject
{
    public static DataManager Instance;

    [Header("�÷��̾�")]
    public float PlayerHp;
    public float MaxPlayerHp = 1000f;
    public float PlayerSpeed;
    public float PlayerPower;
    public float HpPlus = 200f;

    [Header("����")]
    public float Coin = 0;
    public float CoinPlus = 50;

    [Header("�����ڽ�")]
    public int SkillIndex;
    public Sprite[] newsprite;

    [Header("��")]
    public int BulletIndex;
    public Sprite[] BulletSprite;


    public void Init()
    {
        Instance = this;
    }
}