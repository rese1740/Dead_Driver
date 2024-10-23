using UnityEngine;

public class SlowCar : MonoBehaviour
{
    public static Car Instance;

    public float CarSpeed = 500f;
    public float CrushCount = 50;

    public GameObject RedPanel;

    private void Start()
    {
        RedPanel.SetActive(true);

        Invoke("RedPanelDown", 1f);
        Invoke("CarDestroy", 5f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * CarSpeed;
    }
    void RedPanelDown()
    {
        RedPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DataManager.Instance.PlayerHp -= CrushCount;
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Barrier") || collision.CompareTag("Wave"))
        {
            DataManager.Instance.PlayerHp -= CrushCount;
        }
    }

    public void CarDestroy()
    {
        Destroy(gameObject);
    }
}
