using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public bool MTime = true;
    public bool YTime = true;







    private void OnTriggerEnter2D(Collider2D collision)
    {
    int randomBoxIndex = Random.Range(0, 4);
   

        if(randomBoxIndex == 0)
        {
            //ºÒ¼Ò¿ø¼¦
        }
        else if(randomBoxIndex == 1)
        {
            //Å¬¶ô¼Ç
        }
        else  if (randomBoxIndex == 2)
        {
            //Èû Áõ°¡
        }
        else if ((randomBoxIndex == 4))
        {
            //½Çµå
        }
        else
        {
            //µ· 2¹è
        }

    }

    private void Update()
    {
        if (MTime)
        {
            
            Invoke("StopMTime",3f);
            MTime = false;
        }
    }


    public void StopMTime()
    {
        transform.position += Vector3.down * 0.1f;

    }
   
}
