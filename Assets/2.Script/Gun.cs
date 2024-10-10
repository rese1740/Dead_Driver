using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Timediff;
    public float GunTimer = 0f;


    public GameObject Bullet_;

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


        GameObject newBullet3 = Instantiate(Bullet_);
        GameObject newBullet4 = Instantiate(Bullet_);
            newBullet3.transform.position = Player.position + new Vector3(0.576f, 0);
            newBullet4.transform.position = Player.position + new Vector3(-0.551f, 0);
            yield return new WaitForSeconds(0.1f);


        GameObject newBullet5 = Instantiate(Bullet_);
        GameObject newBullet6 = Instantiate(Bullet_);
            newBullet5.transform.position = Player.position + new Vector3(0.576f, 0);
            newBullet6.transform.position = Player.position + new Vector3(-0.551f, 0);
            yield return new WaitForSeconds(Timediff);

        }
    }

}
