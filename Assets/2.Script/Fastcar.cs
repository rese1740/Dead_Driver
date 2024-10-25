using UnityEngine;

public class FastCar : MonoBehaviour
{
    public static FastCar Instance;

    public float speedIncrease = 10000;
    private Transform player; // 플레이어의 Transform
    public float CrushCount = 100f;
    public float Spood = 500f;

    public GameObject RedPanel2;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Instance = this;
        RedPanel2.SetActive(true);

        Invoke("RedPanelDown", 1f);
        Invoke("CarDestroy", 20f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * Spood;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < 3f)
        {
            Spood = speedIncrease; // 속도 증가
        }
        else
        {
            Spood = 10; 
        }
    }
    void RedPanelDown()
    {
        RedPanel2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Disable"))
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
