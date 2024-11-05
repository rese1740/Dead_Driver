using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotanMovement : MonoBehaviour
{
    public float speed = 10f; // 작은 포탄의 이동 속도
    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized; // 방향 초기화
    }

    private void Update()
    {
        // 설정된 방향으로 이동
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
