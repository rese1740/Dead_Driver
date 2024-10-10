using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public float BulletSpeed = 2;
    public Vector3 targetPosition; // 이동할 목표 지점
    private bool hasArrived = false; // 도착 여부

    private void Update()
    {
        if (!hasArrived)
        {
            MovinTar();
        }
    }

    private void MovinTar()
    {
        // 목표 지점까지의 방향을 계산
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;

        // 목표 지점에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            hasArrived = true; // 도착 시 이동 중지
            transform.position = targetPosition; // 정확한 위치로 설정
        }
    }
}


