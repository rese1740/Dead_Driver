using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car Instance;

    public float Spood = 500f;

    public GameObject RedPanel2;

    private void Start()
    {
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
        if (collision.CompareTag("Player") || collision.CompareTag("Barrier") || collision.CompareTag("Wave"))
        {
            Destroy(gameObject);
        }
    }

    public void CarDestroy()
    {
        Destroy(gameObject);
    }
}
