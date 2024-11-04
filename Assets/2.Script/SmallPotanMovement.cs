using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotanMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized; // 방향을 초기화하고 정규화
    }

    void Update()
    {
        // 매 프레임마다 주어진 방향으로 이동
        transform.position += direction * speed * Time.deltaTime;
    }
}
