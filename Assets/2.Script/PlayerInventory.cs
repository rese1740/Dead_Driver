using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    private List<Item> items = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        
    }

    public void UseItem()
    {
        if (items.Count > 0)
        {
            Item itemToUse = items[0]; // 첫 번째 아이템 사용 (예시)
            items.RemoveAt(0); // 사용 후 아이템 제거
        }
        else
        {
            Debug.Log("사용할 아이템이 없습니다.");
        }
    }
}
