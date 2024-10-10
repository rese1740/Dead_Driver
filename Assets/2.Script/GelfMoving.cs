using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelfMoving : MonoBehaviour
{
    public float GelfSpeed = 2;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * GelfSpeed;
    }
}
