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
            //�Ҽҿ���
            Debug.Log(1);
        }
        else if(randomBoxIndex == 1)
        {
            //Ŭ����
            Debug.Log(2);
        }
        else  if (randomBoxIndex == 2)
        {
            //�� ����
            Debug.Log(3);
        }
        else if ((randomBoxIndex == 4))       
        {
            //�ǵ�
            Debug.Log(4);
        }
        else
        {
            //�� 2��
            Debug.Log(5);
        }

    }

}
