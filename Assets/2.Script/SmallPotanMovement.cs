using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotanMovement : MonoBehaviour
{
    public float speed = 10f; // ���� ��ź�� �̵� �ӵ�
    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized; // ���� �ʱ�ȭ
    }

    private void Update()
    {
        // ������ �������� �̵�
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
