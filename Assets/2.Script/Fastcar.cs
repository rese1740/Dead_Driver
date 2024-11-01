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
    public float forceAmount = 50f; // 힘의 크기 증가
  

    private void Start()
    {

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
            if (gameObject.transform.position.y <= 4)
            {
                Debug.Log(1);
                float randomDirection = Random.Range(-1f, 1f); // -1과 1 사이의 랜덤 값
                force += new Vector3(randomDirection, 0, -1);
            }
        }

        if (force != Vector3.zero)
        {
            rb.AddForce(force.normalized * forceAmount); // 랜덤한 힘 추가
        }


        if (gameObject.CompareTag("Dolzin"))
        {

            if (distance < 3f)
            {
                Spood = speedIncrease; // 속도 증가
                audioSource.Play();
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

            }
            else if (collision.CompareTag("Barrier") || collision.CompareTag("Wave"))
            {
                DataManager.Instance.PlayerHp -= CrushCount;
            }
        }
        Destroy(gameObject);
    }

    public void CarDestroy()
    {
        Destroy(gameObject);
    }
}
