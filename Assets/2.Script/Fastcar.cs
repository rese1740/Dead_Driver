using System.Collections;
using UnityEngine;

public class FastCar : MonoBehaviour
{
    public static FastCar Instance;
    private Rigidbody2D rb;
    private Transform player; // 플레이어의 Transform

    [Header("경찰차")]
    public float speedIncrease = 10000;

    [Header("설정")]
    public float CrushCount = 100f;
    public float Spood = 500f;
    public AudioSource audioSource;
    public GameObject RedPanel2;

    [Header("아반떼")]
    public float moveAmount = 5f;  // 좌우 이동 범위
    public float resetTime = 2f;   // 좌우 이동 후 밑으로 내려가는 시간 (초)
    private Vector3 initialPosition;  // 원래 위치
    private bool Steal = true;
    private bool isExecuted = false;


    private void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        audioSource = player.GetComponent<AudioSource>();
        Instance = this;
        RedPanel2.SetActive(true); 

        Invoke("RedPanelDown", 1f);
        Invoke("CarDestroy", 20f);
    }

    void Update()
    {
        Vector3 force = Vector3.zero;

        transform.position += Vector3.down * Time.deltaTime * Spood;

        float distance = Vector3.Distance(transform.position, player.position);

        if (gameObject.CompareTag("RedCar"))
        {
            if (gameObject.transform.position.y <= 7) // Y좌표에 대한 조건 (기존 코드 유지)
            {
                if (gameObject.transform.position.x >= -5f && gameObject.transform.position.x <= 5f)
                {
                    if (Steal && !isExecuted)  // 실행 여부를 확인
                    {
                        float randomDirection = Random.Range(-1f, 1f);  // -1과 1 사이의 랜덤 값

                        transform.Translate(Vector3.right * randomDirection * moveAmount * Time.deltaTime);

                        Steal = false;        // Steal을 false로 설정
                        isExecuted = true;     // 이미 실행된 상태로 설정
                    }
                }
            }
        }

        if (gameObject.CompareTag("Dolzin"))
        {

            if (distance < 5f)
            {
                Spood = speedIncrease; // 속도 증가
            }
            else
            {
                Spood = 10;
            }
        }
    }
    void RedPanelDown()
    {
        RedPanel2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Disable") || gameObject.CompareTag("RedCar") || gameObject.CompareTag("Dolzin"))
        {
            if (collision.CompareTag("Player"))
            {
                DataManager.Instance.PlayerHp -= CrushCount;
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Barrier") || collision.CompareTag("Wave"))
            {
                Destroy(gameObject);
            }
        }
    }

    public void CarDestroy()
    {
        Destroy(gameObject);
    }
}
