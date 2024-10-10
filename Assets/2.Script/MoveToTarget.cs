using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public float BulletSpeed = 2;
    public Vector3 targetPosition; // �̵��� ��ǥ ����
    private bool hasArrived = false; // ���� ����

    private void Update()
    {
        if (!hasArrived)
        {
            MovinTar();
        }
    }

    private void MovinTar()
    {
        // ��ǥ ���������� ������ ���
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;

        // ��ǥ ������ �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            hasArrived = true; // ���� �� �̵� ����
            transform.position = targetPosition; // ��Ȯ�� ��ġ�� ����
        }
    }
}


