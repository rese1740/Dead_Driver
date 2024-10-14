using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car Instance;

    public float GelfSpeed = 500f;

    public GameObject RedPanel;

    private void Start()
    {
        RedPanel.SetActive(true);

        Invoke("RedPanelDown", 1f);
        Invoke("CarDestroy", 5f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * GelfSpeed;
    }
    void RedPanelDown()
    {
        RedPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void CarDestroy()
    {
        Destroy(gameObject);
    }
}
