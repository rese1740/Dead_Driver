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
            Item itemToUse = items[0]; // ù ��° ������ ��� (����)
            items.RemoveAt(0); // ��� �� ������ ����
        }
        else
        {
            Debug.Log("����� �������� �����ϴ�.");
        }
    }
}
