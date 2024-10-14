using System.Collections;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static CarManager Instance;

    public bool isActivated = true;

    public Transform[] positions;

    public GameObject[] objectsToSpawn;

    public GameObject[] Item;

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
        
            // 위치 
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition = positions[randomPositionIndex];

            // 오브젝트 
            int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject randomObject = objectsToSpawn[randomObjectIndex];

            int randomPositionIndex1 = Random.Range(0, positions.Length);
            Transform randomPosition1 = positions[randomPositionIndex1];

            int ItemIndex = Random.Range(0, Item.Length);
            GameObject randomItem = Item[ItemIndex];


            Instantiate(randomObject, randomPosition.position, randomPosition.rotation);

            Instantiate(randomItem, randomPosition1.position, randomPosition1.rotation);

            yield return new WaitForSeconds(3f);
        }


        
        while (isActivated == false)
        {
            // 위치 
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition = positions[randomPositionIndex];

            // 오브젝트 
            int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject randomObject = objectsToSpawn[randomObjectIndex];

            int randomPositionIndex1 = Random.Range(0, positions.Length);
            Transform randomPosition1 = positions[randomPositionIndex1];

            int ItemIndex = Random.Range(0, Item.Length);
            GameObject randomItem = Item[ItemIndex];


            Instantiate(randomObject, randomPosition.position, randomPosition.rotation);

            Instantiate(randomItem, randomPosition1.position, randomPosition1.rotation);

            yield return new WaitForSeconds(3f);
        }
    }


}


