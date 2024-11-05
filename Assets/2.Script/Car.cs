using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car Instance;

    public float Spood = 500f;
    public float CrushCount = 10f;
    public float CoinCount = 10f;

    private void Start()
    {
        Instance = this;

        Invoke("CarDestroy", 20f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * Spood;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Disable"))
        {
            if (collision.CompareTag("Player"))
            {
                DataManager.Instance.PlayerHp -= CrushCount;
                DataManager.Instance.Coin -= CoinCount;
}
            else if (collision.CompareTag("Barrier") || collision.CompareTag("Wave"))
            {
                Destroy(gameObject);
            }
        }
       
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
