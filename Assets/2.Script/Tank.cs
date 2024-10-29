using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject bulletPrefab; // ��ź ������
    public Vector2 spawnAreaMin;    // ���� ���� �ּ� ��ǥ
    public Vector2 spawnAreaMax;    // ���� ���� �ִ� ��ǥ
    public float spawnInterval = 1f; // ���� ����

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

            // ��ź ����
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
