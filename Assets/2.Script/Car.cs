using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car Instance;

    public float Spood = 500f;
    public float CrushCount = 10f;

    public GameObject RedPanel2;

    private void Start()
    {
        Instance = this;
        RedPanel2.SetActive(true);

        Invoke("RedPanelDown", 1f);
        Invoke("CarDestroy", 20f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * Spood;
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
        else  if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    
    }

    public void CarDestroy()
    {
        Destroy(gameObject);
    }
}
