using System.Collections;
using UnityEngine;

public class FastCar : MonoBehaviour
{
    public static FastCar Instance;
    private Rigidbody2D rb;
    private Transform player; // �÷��̾��� Transform

    [Header("������")]
    public float speedIncrease = 10000;

    [Header("����")]
    public float CrushCount = 100f;
    public float Spood = 500f;
    public AudioSource audioSource;
    public GameObject RedPanel2;

    [Header("�ƹݶ�")]
    public float moveAmount = 5f;  // �¿� �̵� ����
    public float resetTime = 2f;   // �¿� �̵� �� ������ �������� �ð� (��)
    private Vector3 initialPosition;  // ���� ��ġ
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
            if (gameObject.transform.position.y <= 7) // Y��ǥ�� ���� ���� (���� �ڵ� ����)
            {
                if (gameObject.transform.position.x >= -5f && gameObject.transform.position.x <= 5f)
                {
                    if (Steal && !isExecuted)  // ���� ���θ� Ȯ��
                    {
                        float randomDirection = Random.Range(-1f, 1f);  // -1�� 1 ������ ���� ��

                        transform.Translate(Vector3.right * randomDirection * moveAmount * Time.deltaTime);

                        Steal = false;        // Steal�� false�� ����
                        isExecuted = true;     // �̹� ����� ���·� ����
                    }
                }
            }
        }

        if (gameObject.CompareTag("Dolzin"))
        {

            if (distance < 5f)
            {
                Spood = speedIncrease; // �ӵ� ����
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
