using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(LaserBim());
    }

   
    IEnumerator LaserBim()
    {

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
