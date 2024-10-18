using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMAnager : MonoBehaviour
{


    public GameObject redObjectPrefab; // 레드 오브젝트 프리팹
    public GameObject laserPrefab; // 레이저 프리팹

    private void Start()
    {
        StartCoroutine(SpawnRedAndLaser());
    }

    private IEnumerator SpawnRedAndLaser()
    {
        // 레드 오브젝트 소환
        GameObject redObject = Instantiate(redObjectPrefab, transform.position, Quaternion.identity);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 레드 오브젝트 삭제
        Destroy(redObject);

        // 레이저 소환
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 레이저 삭제
        Destroy(laser);
    }

}
