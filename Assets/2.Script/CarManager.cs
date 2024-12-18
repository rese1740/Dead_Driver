using System.Collections;
using UnityEngine;




public class CarManager : MonoBehaviour
{
    public static CarManager Instance;


    public bool isActivated = true;

    public Transform[] positions;

    public GameObject[] objectsToSpawn;

    public GameObject[] objectsToSpawn2;

    public GameObject[] objectsToSpawn3;

    public GameObject laser;

    public GameObject randomBox;

    public GameObject[] Item;

    public GameObject[] SlowlyCar;

    private void Start()
    {
        Instance = this;
        StartCoroutine(CarSpawn());
        StartCoroutine(Laserspawn());
        StartCoroutine(randomBoxspawn());
        StartCoroutine(ItemSpawn());
    }

    public IEnumerator CarSpawn()
    {
        while (isActivated)
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

            Instantiate(randomObject, randomPosition.position, randomPosition.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
    public IEnumerator Laserspawn()
    {
        while (isActivated)
        {
            if (positions.Length == 0 || objectsToSpawn2.Length == 0)
            {
                yield return null;
            }

            // 위치 
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition = positions[randomPositionIndex];

            // 오브젝트 
            int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject randomObject = objectsToSpawn2[randomObjectIndex];

            Instantiate(randomObject, randomPosition.position, randomPosition.rotation);
            yield return new WaitForSeconds(2f);
            Instantiate(laser, randomPosition.position, randomPosition.rotation);
            yield return new WaitForSeconds(2f);
        }
    }




    public IEnumerator randomBoxspawn()
    {
        while (isActivated)
        {
            if (positions.Length == 0 || objectsToSpawn3.Length == 0)
            {
                yield return null;
            }

            // 랜덤 위치 선택
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition1 = positions[randomPositionIndex];

            // X축 회전을 180도로 설정하고, Y, Z축 회전은 기존 값 유지
            Quaternion modifiedRotation = Quaternion.Euler(180f, randomPosition1.rotation.eulerAngles.y, randomPosition1.rotation.eulerAngles.z);

            // 오브젝트 생성 (회전 적용)
            Instantiate(randomBox, randomPosition1.position, modifiedRotation);

            yield return new WaitForSeconds(15f);
        }
    }


    IEnumerator ItemSpawn()
    {
        while (isActivated)
        {
            int randomPositionIndex1 = Random.Range(0, positions.Length);
            Transform randomPosition1 = positions[randomPositionIndex1];

            int itemIndex = Random.Range(0, Item.Length);
            GameObject randomItem = Item[itemIndex];

            Instantiate(randomItem, randomPosition1.position, randomPosition1.rotation);

            yield return new WaitForSeconds(3f);
        }
    }
    

    public void RemoveItem()
    {
        if (positions.Length >= 4)
        {
            Transform[] newArray = new Transform[positions.Length - 2];
            System.Array.Copy(positions, newArray, positions.Length - 2);
            positions = newArray; // 새로운 배열로 교체
            Debug.Log($"Removed items. New length: {positions.Length}"); // 로그 추가
        }
    }


    // 예를 들어 이 메서드를 통해 RemoveItem 호출 가능
    public void DeactivateAndRemoveItems()
    {
        RemoveItem(); // 한 번만 호출
    }
}
