using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dastroty : MonoBehaviour
{

    public float lifetime = 1f; // 포탄이 사라지는 시간

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
                Destroy(gameObject);
            }
        }
    }
}
