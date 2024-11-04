using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotanMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized; // ������ �ʱ�ȭ�ϰ� ����ȭ
    }

    void Update()
    {
        // �� �����Ӹ��� �־��� �������� �̵�
        transform.position += direction * speed * Time.deltaTime;
    }
}
