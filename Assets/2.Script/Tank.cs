using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Tank : MonoBehaviour
{
    public GameObject bulletPrefab; // ��ź ������
    public Vector2 spawnAreaMin;    // ���� ���� �ּ� ��ǥ
    public Vector2 spawnAreaMax;    // ���� ���� �ִ� ��ǥ
    public float spawnInterval = 1f; // ���� ����

    public float BulletSpeed = 2;
    public Vector3 targetPosition; // �̵��� ��ǥ ����
    public Vector3 targetPosition1;
    private bool hasArrived = true; // ���� ����
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

            // ��ź ����
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
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
            Restarting = false;
            transform.position = transform.position + new Vector3(0,20, 0);
        }
    }

    private void MovinTar1()
    {
        // ��ǥ ���������� ������ ���
        Vector3 direction = (targetPosition1 - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;
        BossUI.Instance.BossHp -= 1f;

        // ��ǥ ������ �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetPosition1) < 0.1f)
        {
            Restarting = true;
        }
    }
}
