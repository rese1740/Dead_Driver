using System.Collections;
using UnityEngine;

public class Tank : MonoBehaviour
{

    [Header("����1")]
    public GameObject bulletPrefab;
    public GameObject redcircle;// ��ź ������
    public Vector2 spawnAreaMin;    // ���� ���� �ּ� ��ǥ
    public Vector2 spawnAreaMax;    // ���� ���� �ִ� ��ǥ
    public float spawnInterval = 1f; // ���� ����


    [Header("����2")]
    public GameObject tang;
    public float TangSpeed = 2;
    private bool TangBool = true;
    public Transform spawnTang;

    [Header("��ũ�̵�")]
    public float BulletSpeed = 2;
    public Vector3 targetPosition; // �̵��� ��ǥ ���� //sex
    public Vector3 targetPosition1;
    private bool hasArrived = true; // ���� ���� //analsex
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
        // ��ǥ ���������� ������ ���
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;
        //shit
        // ��ǥ ������ �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            hasArrived = true; // ���� �� �̵� ����
            Restarting = false;
            transform.position = transform.position + new Vector3(0, 20, 0);
        }
    }

    private void MovinTar1()
    {
        //fuck
        // ��ǥ ���������� ������ ���
        Vector3 direction = (targetPosition1 - transform.position).normalized;
        transform.position += direction * BulletSpeed * Time.deltaTime;
        BossUI.Instance.BossHp -= 1f;
        //asshole
        // ��ǥ ������ �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetPosition1) < 0.1f)
        {
            Restarting = true;
        }
    }
}
