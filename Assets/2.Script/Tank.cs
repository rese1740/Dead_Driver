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
    public GameObject tang;               // Tang 오브젝트
    public GameObject smallPotan;         // SmallPotan 오브젝트
    public Transform spawnTang;           // Tang 오브젝트 생성 위치
    public float speed = 5f;              // Tang 이동 속도
    public float targetHeight = 5f;       // Tang의 목표 높이
    public Vector3[] targetPositions;

    [Header("탕크이동")]
    public Vector3 targetPosition; // 목표 위치
    public float Tankspeed = 5f; // 이동 속도
    public Vector3 originalPosition; // 원래 위치
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
        // Tang 인스턴스 생성
        GameObject tangInstance = Instantiate(tang, spawnTang.position, Quaternion.identity);

        // 3개의 목표 위치 중 하나를 랜덤으로 선택
        int randomIndex = Random.Range(0, targetPositions.Length);
        Vector3 randomTargetPosition = targetPositions[randomIndex];

        // Tang이 목표 높이에 도달할 때까지 이동
        while (tangInstance.transform.position.y > targetHeight)
        {
            // 목표 위치를 설정 (y축만 targetHeight로 고정)
            Vector3 targetPosition = new Vector3(randomTargetPosition.x, targetHeight, randomTargetPosition.z);

            // tangInstance가 목표 위치로 이동하도록 설정
            tangInstance.transform.position = Vector3.MoveTowards(tangInstance.transform.position, targetPosition, speed * Time.deltaTime);

            // 매 프레임마다 조금씩 이동
            yield return new WaitForFixedUpdate();
        }

        // 목표에 도달했을 때, 작은 포탄을 방사형으로 발사
        if (tangInstance.transform.position.y <= targetHeight)
        {
            int numberOfProjectiles = 12;
            float angleStep = 360f / numberOfProjectiles;

            // tangInstance를 파괴하지 않고, 작은 포탄을 발사
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                // 방사형으로 작은 포탄을 발사
                float angle = i * angleStep;
                Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                GameObject smallPotanInstance = Instantiate(smallPotan, tangInstance.transform.position, Quaternion.LookRotation(Vector3.forward, direction));

                // SmallPotanMovement 스크립트를 가져와서 방향 초기화
                SmallPotanMovement potanMovement = smallPotanInstance.GetComponent<SmallPotanMovement>();
                if (potanMovement != null)
                {
                    potanMovement.Initialize(direction); // 방향을 초기화
                }
            }

            // Tang 인스턴스 삭제
            Destroy(tangInstance);
        }
    }






private void MovinTar()
    {
        // 목표 지점까지의 방향을 계산
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * Tankspeed * Time.deltaTime;

        // 목표 지점에 도달했는지 확인
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            ismoving = false; // 도착 시 이동 중지
            isStop = true;
        }
    }

    private void MovinTar1()
    {
        Vector3 returnDirection = (originalPosition - transform.position).normalized;
        transform.position += returnDirection * Tankspeed * Time.deltaTime;

        // 원래 자리 도달 확인
        if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
        {
            Debug.Log(1);

            isStop = false; // 원래 자리 도착 시 이동 중지
            transform.position = originalPosition; // 정확한 위치로 설정
        }
    }
}
