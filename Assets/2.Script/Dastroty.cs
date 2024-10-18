using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dastroty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Dostroy", 2f);
    }

    // Update is called once per frame
   void Dostroy()
    {
        Destroy(gameObject);
    }
}
