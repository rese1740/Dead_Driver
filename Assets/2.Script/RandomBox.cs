using UnityEngine;

public class RandomBox : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(gameObject);
    }

}
