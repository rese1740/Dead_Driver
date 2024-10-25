using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dastroty : MonoBehaviour
{

    void Start()
    {
        Invoke("Dostroy", 2f);
    }

   void Dostroy()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
