using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance;
    
    public float BulletSpeed = 2;

    private void Start()
    {
        Instance = this;
        StartCoroutine(DeleteBullet());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss")) 
        {
            BossUI.Instance.BossHp -= DataManager.Instance.PlayerPower;
            Destroy(gameObject); 
        }
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * BulletSpeed;
    }

    private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
