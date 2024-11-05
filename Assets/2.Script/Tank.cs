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
    public GameObject tang;               // Tang ������Ʈ
    public GameObject smallPotan;         // SmallPotan ������Ʈ
    public Transform spawnTang;           // Tang ������Ʈ ���� ��ġ
    public float speed = 5f;              // Tang �̵� �ӵ�
    public float targetHeight = 5f;       // Tang�� ��ǥ ����
    public Vector3[] targetPositions;

    [Header("��ũ�̵�")]
    public Vector3 targetPosition; // ��ǥ ��ġ
    public float Tankspeed = 5f; // �̵� �ӵ�
    public Vector3 originalPosition; // ���� ��ġ
    public bool ismoving = false;
    private bool isGoing = false;
    private bool isStop = false;
    private bool isRed = true;
    public GameObject RedPanel;


    private void Start()
    {
        StartCoroutine(SpawnAndBigPotan());
    }


    private void Update()
    {
        if (BossUI.Instance.BossHp <= 5000)
        {
            if (isGoing)
            {
                ismoving = true;
                isGoing = false;
            }
        }
        if (BossUI.Instance.BossHp <= 5000)
        {
            if (isRed)
            {
                isRed = false;
                StartCoroutine(RedPanelOpen());
            }
        }

        if (ismoving)
        {
            MovinTar();
        }
        else if (isStop)
        {
            MovinTar1();
        }
    }

    IEnumerator RedPanelOpen()
    {

        RedPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RedPanel.SetActive(false);
        isGoing = true;

    }

    IEnumerator SpawnAndBigPotan()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(1.0f);
            yield return StartCoroutine(BigPotan());
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SpawnBullet()
    {
        Vector2[] spawnPositions = new Vector2[3];

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            spawnPositions[i] = new Vector2(x, y);
        }

        foreach (var position in spawnPositions)
        {
            Instantiate(redcircle, position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1);

        foreach (var position in spawnPositions)
        {
            Instantiate(bulletPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator BigPotan()
    {
        // Tang �ν��Ͻ� ����
        GameObject tangInstance = Instantiate(tang, spawnTang.position, Quaternion.identity);

        // 3���� ��ǥ ��ġ �� �ϳ��� �������� ����
        int randomIndex = Random.Range(0, targetPositions.Length);
        Vector3 randomTargetPosition = targetPositions[randomIndex];

        // Tang�� ��ǥ ���̿� ������ ������ �̵�
        while (tangInstance.transform.position.y > targetHeight)
        {
            // ��ǥ ��ġ�� ���� (y�ุ targetHeight�� ����)
            Vector3 targetPosition = new Vector3(randomTargetPosition.x, targetHeight, randomTargetPosition.z);

            // tangInstance�� ��ǥ ��ġ�� �̵��ϵ��� ����
            tangInstance.transform.position = Vector3.MoveTowards(tangInstance.transform.position, targetPosition, speed * Time.deltaTime);

            // �� �����Ӹ��� ���ݾ� �̵�
            yield return new WaitForFixedUpdate();
        }

        // ��ǥ�� �������� ��, ���� ��ź�� ��������� �߻�
        if (tangInstance.transform.position.y <= targetHeight)
        {
            int numberOfProjectiles = 12;
            float angleStep = 360f / numberOfProjectiles;

            // tangInstance�� �ı����� �ʰ�, ���� ��ź�� �߻�
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                // ��������� ���� ��ź�� �߻�
                float angle = i * angleStep;
                Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                GameObject smallPotanInstance = Instantiate(smallPotan, tangInstance.transform.position, Quaternion.LookRotation(Vector3.forward, direction));

                // SmallPotanMovement ��ũ��Ʈ�� �����ͼ� ���� �ʱ�ȭ
                SmallPotanMovement potanMovement = smallPotanInstance.GetComponent<SmallPotanMovement>();
                if (potanMovement != null)
                {
                    potanMovement.Initialize(direction); // ������ �ʱ�ȭ
                }
            }

            // Tang �ν��Ͻ� ����
            Destroy(tangInstance);
        }
    }






private void MovinTar()
    {
        // ��ǥ ���������� ������ ���
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * Tankspeed * Time.deltaTime;

        // ��ǥ ������ �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            ismoving = false; // ���� �� �̵� ����
            isStop = true;
        }
    }

    private void MovinTar1()
    {
        Vector3 returnDirection = (originalPosition - transform.position).normalized;
        transform.position += returnDirection * Tankspeed * Time.deltaTime;

        // ���� �ڸ� ���� Ȯ��
        if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
        {
            Debug.Log(1);

            isStop = false; // ���� �ڸ� ���� �� �̵� ����
            transform.position = originalPosition; // ��Ȯ�� ��ġ�� ����
        }
    }
}
