using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class Gun : MonoBehaviour
{
    public float Timediff;
    public float GunTimer = 0f;


    public GameObject Bullet_;
    public Sprite Bullets;

    public Transform Player;

    private void Start()
    {
        StartCoroutine(Shooting());
    }


    public IEnumerator Shooting()
    {
        while (true)
        {
            GameObject newBullet1 = Instantiate(Bullet_);
            GameObject newBullet2 = Instantiate(Bullet_);
            newBullet1.transform.position = Player.position + new Vector3(0.576f, 0);
            newBullet2.transform.position = Player.position + new Vector3(-0.551f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
