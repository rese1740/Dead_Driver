using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomBoxIndex = Random.Range(0, 4);
   
        if(randomBoxIndex == 0)
        {
            //ºÒ¼Ò¿ø¼¦
            Debug.Log(1);
        }
        else if(randomBoxIndex == 1)
        {
            //Å¬¶ô¼Ç
            Debug.Log(2);
        }
        else  if (randomBoxIndex == 2)
        {
            //Èû Áõ°¡
            Debug.Log(3);
        }
        else if ((randomBoxIndex == 4))       
        {
            //½Çµå
            Debug.Log(4);
        }
        else
        {
            //µ· 2¹è
            Debug.Log(5);
        }

    }

}
