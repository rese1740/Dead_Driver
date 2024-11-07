using System.Collections;
using UnityEngine;

public class PoPo : MonoBehaviour
{
    public GameObject projectilePrefab; // 단발 투사체 프리팹
    public GameObject spreadProjectilePrefab; // 퍼지는 포탄 프리팹
    public Transform player; // 플레이어 트랜스폼
    public float fireRate = 0.5f; // 발사 간격
    public float projectileSpeed = 5f; // 투사체 속도
    public float spreadDelay = 1f; // 퍼지는 포탄 발사 지연 시간
    public int initialProjectileCount = 4; // 발사할 투사체 개수
    public int spreadProjectileCount = 5; // 퍼지는 포탄 개수
    public float spreadAngle = 45f; // 퍼지는 각도
    public float attackInterval = 5f; // 공격 간격

    private float nextAttackTime = 0f;
    private bool Ang =true;

    private bool isStop = false;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(FireProjectiles());
            nextAttackTime = Time.time + attackInterval; // 다음 공격 시간 설정
        }

        if (isStop)
        {
            StopCoroutine(FireProjectiles());
        }


        if(BossUI.Instance.BossHp <= 100)
        {
            if(Ang)
            {
            DataManager.Instance.Coin += 50;
                Ang = false;
            }
        }
    }

    private IEnumerator FireProjectiles()
    {
        for (int i = 0; i < initialProjectileCount; i++)
        {
            FireSingleProjectile();
            yield return new WaitForSeconds(fireRate); // 각 발사 사이의 대기 시간
        }

        // 퍼지는 포탄 발사
        yield return new WaitForSeconds(spreadDelay);
        FireSpreadProjectiles();
    }

    void FireSingleProjectile()
    {
        // 플레이어 방향 계산
        Vector2 direction = (player.position - transform.position).normalized;

        // 단발 투사체 발사
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }

    void FireSpreadProjectiles()
    {
        // 플레이어 방향 계산
        Vector2 direction = (player.position - transform.position).normalized;

        for (int i = 0; i < spreadProjectileCount; i++)
        {
            float angle = spreadAngle * (i - (spreadProjectileCount - 1) / 2f) / (spreadProjectileCount - 1);
            Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * direction;

            GameObject spreadProjectile = Instantiate(spreadProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = spreadProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = spreadDirection * projectileSpeed;
        }
    }
}
