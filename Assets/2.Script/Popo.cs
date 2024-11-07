using System.Collections;
using UnityEngine;

public class PoPo : MonoBehaviour
{
    public GameObject projectilePrefab; // �ܹ� ����ü ������
    public GameObject spreadProjectilePrefab; // ������ ��ź ������
    public Transform player; // �÷��̾� Ʈ������
    public float fireRate = 0.5f; // �߻� ����
    public float projectileSpeed = 5f; // ����ü �ӵ�
    public float spreadDelay = 1f; // ������ ��ź �߻� ���� �ð�
    public int initialProjectileCount = 4; // �߻��� ����ü ����
    public int spreadProjectileCount = 5; // ������ ��ź ����
    public float spreadAngle = 45f; // ������ ����
    public float attackInterval = 5f; // ���� ����

    private float nextAttackTime = 0f;
    private bool Ang =true;

    private bool isStop = false;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(FireProjectiles());
            nextAttackTime = Time.time + attackInterval; // ���� ���� �ð� ����
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
            yield return new WaitForSeconds(fireRate); // �� �߻� ������ ��� �ð�
        }

        // ������ ��ź �߻�
        yield return new WaitForSeconds(spreadDelay);
        FireSpreadProjectiles();
    }

    void FireSingleProjectile()
    {
        // �÷��̾� ���� ���
        Vector2 direction = (player.position - transform.position).normalized;

        // �ܹ� ����ü �߻�
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }

    void FireSpreadProjectiles()
    {
        // �÷��̾� ���� ���
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
