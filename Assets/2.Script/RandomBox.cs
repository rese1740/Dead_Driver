using UnityEngine;

public class RandomBox : MonoBehaviour
{

    public GameObject randombox;
    
    private void Start()
    {
        Instantiate(randombox);
        Instantiate(randombox);
        Instantiate(randombox);
        Instantiate(randombox);
        Instantiate(randombox);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(gameObject);
    }

}
