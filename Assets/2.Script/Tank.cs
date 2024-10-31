using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Tank : MonoBehaviour
{
    public GameObject bulletPrefab; // 포탄 프리팹
    public Vector2 spawnAreaMin;    // 생성 영역 최소 좌표
    public Vector2 spawnAreaMax;    // 생성 영역 최대 좌표
    public float spawnInterval = 1f; // 생성 간격

    public float BulletSpeed = 2;
    public Vector3 targetPosition; // 이동할 목표 지점
    public Vector3 targetPosition1;
    private bool hasArrived = true; // 도착 여부
    private bool Restarting = true;

    private void Start()
    {
        StartCoroutine(SpawnBullet());
    }


    private void Update()
    {
        if(BossUI.Instance.BossHp == 5000 || BossUI.Instance.BossHp == 4000)
        {
            hasArrived = false;
        }

        if (!hasArrived)
        {
            MovinTar();
        }

        if(!Restarting)
        {
            MovinTar1();
        }
    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(x, y);

            // 포탄 생성
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
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
            Restarting = false;
            transform.position = transform.position + new Vector3(0,20, 0);
        }
    }

    private void MovinTar1()
    {
        // 목표 지점까지의 방향을 계산
        Vector3 direction = (targetPosition1 - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;
        BossUI.Instance.BossHp -= 1f;

        // 목표 지점에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition1) < 0.1f)
        {
            Restarting = true;
        }
    }
}
