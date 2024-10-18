using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMAnager : MonoBehaviour
{


    public GameObject redObjectPrefab; // ���� ������Ʈ ������
    public GameObject laserPrefab; // ������ ������

    private void Start()
    {
        StartCoroutine(SpawnRedAndLaser());
    }

    private IEnumerator SpawnRedAndLaser()
    {
        // ���� ������Ʈ ��ȯ
        GameObject redObject = Instantiate(redObjectPrefab, transform.position, Quaternion.identity);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // ���� ������Ʈ ����
        Destroy(redObject);

        // ������ ��ȯ
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // ������ ����
        Destroy(laser);
    }

}
