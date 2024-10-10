using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool isActivated = true;

    public Transform[] positions;

    public GameObject[] objectsToSpawn;

    private void Start()
    {
        StartCoroutine(CarSpawn());
    }


    public IEnumerator CarSpawn()
    {
        while (isActivated == true)
        {

            if (positions.Length == 0 || objectsToSpawn.Length == 0)
            {
                yield return null;
            }

            // ��ġ 
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition = positions[randomPositionIndex];

            // ������Ʈ 
            int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject randomObject = objectsToSpawn[randomObjectIndex];


            Instantiate(randomObject, randomPosition.position, randomPosition.rotation);

            yield return new WaitForSeconds(3f);
        }
    }
}
