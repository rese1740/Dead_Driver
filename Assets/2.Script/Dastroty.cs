using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dastroty : MonoBehaviour
{

    public float lifetime = 1f; // ��ź�� ������� �ð�
    public float Damage = 100f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Disable"))
        {
            if (collision.CompareTag("Player"))
            {
                DataManager.Instance.PlayerHp -= Damage;
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
