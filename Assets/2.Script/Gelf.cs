using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gelf : MonoBehaviour
{
    public GameObject Gelf_;
    public float Timediff;
    float GelfTimer = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        GelfTimer += Time.deltaTime;
        if(GelfTimer > Timediff)
        {
            GameObject newGelf = Instantiate(Gelf_);
            newGelf.transform.position = new Vector3(11.42f, -Random.Range(-5.17f, 4.93f), 0);
            GelfTimer = 0f;

            Destroy(newGelf, 10.0f);
        }

    }
}
