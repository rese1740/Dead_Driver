using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataManager : ScriptableObject
{
    public static DataManager Instance;

    [Header("플레이어")]
    public float PlayerHp;
    public float PlayerSpeed;
    public float PlayerPower;
    public float HpPlus = 200f;

    [Header("코인")]
    public float Coin = 0;
    public float CoinPlus = 50;

    public void Init()
    {
        Instance = this;
    }
}
