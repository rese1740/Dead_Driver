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
            //�Ҽҿ���
        }
        else if(randomBoxIndex == 1)
        {
            //Ŭ����
        }
        else  if (randomBoxIndex == 2)
        {
            //�� ����
        }
        else if ((randomBoxIndex == 4))
        {
            //�ǵ�
        }
        else
        {
            //�� 2��
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
