using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance;

    public float BulletSpeed = 2;
    public SpriteRenderer spriterenderer;

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

        switch (DataManager.Instance.BulletIndex)
        {
            case 0:
              spriterenderer.sprite = DataManager.Instance.BulletSprite[0];
                break;

            case 1:
                spriterenderer.sprite = DataManager.Instance.BulletSprite[1];
                break;

            case 2:
                spriterenderer.sprite = DataManager.Instance.BulletSprite[2];
                break;

            case 3:
                spriterenderer.sprite = DataManager.Instance.BulletSprite[3];
                break;
        }


        transform.position += Vector3.up * Time.deltaTime * BulletSpeed;
    }

    private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
