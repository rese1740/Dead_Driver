using System.Collections;
using UnityEngine;

public class Tank : MonoBehaviour
{

    [Header("패턴1")]
    public GameObject bulletPrefab;
    public GameObject redcircle;// 포탄 프리팹
    public Vector2 spawnAreaMin;    // 생성 영역 최소 좌표
    public Vector2 spawnAreaMax;    // 생성 영역 최대 좌표
    public float spawnInterval = 1f; // 생성 간격


    [Header("패턴2")]
    public GameObject tang;
    public float TangSpeed = 2;
    private bool TangBool = true;
    public Transform spawnTang;

    [Header("탕크이동")]
    public float BulletSpeed = 2;
    public Vector3 targetPosition; // 이동할 목표 지점 //sex
    public Vector3 targetPosition1;
    private bool hasArrived = true; // 도착 여부 //analsex
    private bool Restarting = true;

    private void Start()
    {
        StartCoroutine(SpawnBullet());
    }


    private void Update()
    {
        if (BossUI.Instance.BossHp == 5000 || BossUI.Instance.BossHp == 4000)
        {
            hasArrived = false;
        }

        if (!hasArrived)
        {
            MovinTar();
        }

        if (!Restarting)
        {
            MovinTar1();
        }
    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            Vector2 spawnPosition = Vector2.zero;
            Vector2 spawnPosition1 = Vector2.zero;
            Vector2 spawnPosition2 = Vector2.zero;
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);



            float x1 = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y1 = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

            float x2 = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y2 = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            spawnPosition = new Vector2(x, y);
            spawnPosition1 = new Vector2(x1, y1);
            spawnPosition2 = new Vector2(x2, y2);

            Instantiate(redcircle, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(redcircle, spawnPosition1, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(redcircle, spawnPosition2, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);

            yield return new WaitForSeconds(1);

            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(bulletPrefab, spawnPosition1, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(bulletPrefab, spawnPosition2, Quaternion.identity);


            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator BigPotan()
    {
        Instantiate(tang, spawnTang);
        TangBool = false;

    yield return null;
    }



    private void MovinTar()
    {
        //sex
        //fuck
        // 목표 지점까지의 방향을 계산
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;
        //shit
        // 목표 지점에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            hasArrived = true; // 도착 시 이동 중지
            Restarting = false;
            transform.position = transform.position + new Vector3(0, 20, 0);
        }
    }

    private void MovinTar1()
    {
        //fuck
        // 목표 지점까지의 방향을 계산
        Vector3 direction = (targetPosition1 - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;
        BossUI.Instance.BossHp -= 1f;
        //asshole
        // 목표 지점에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition1) < 0.1f)
        {
            Restarting = true;
        }
    }
}
