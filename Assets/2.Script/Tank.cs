using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject bulletPrefab; // 포탄 프리팹
    public Vector2 spawnAreaMin;    // 생성 영역 최소 좌표
    public Vector2 spawnAreaMax;    // 생성 영역 최대 좌표
    public float spawnInterval = 1f; // 생성 간격

    private void Start()
    {
        StartCoroutine(SpawnBullet());
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
}
