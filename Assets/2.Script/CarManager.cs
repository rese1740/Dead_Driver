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
        StartCoroutine(SlowCarSpawn());
    }

    public IEnumerator CarSpawn()
    {
        while (isActivated)
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

            // ��ġ 
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition = positions[randomPositionIndex];

            // ������Ʈ 
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

            // ��ġ 
            int randomPositionIndex = Random.Range(0, positions.Length);
            Transform randomPosition = positions[randomPositionIndex];

            Instantiate(randomBox, randomPosition.position, randomPosition.rotation);
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
            positions = newArray; // ���ο� �迭�� ��ü
            Debug.Log($"Removed items. New length: {positions.Length}"); // �α� �߰�
        }
    }

    IEnumerator SlowCarSpawn()
    {
        while (isActivated)
        {
            int randomPositionIndex2 = Random.Range(0, positions.Length);
            Transform randomPosition2 = positions[randomPositionIndex2];

            int slowIndex = Random.Range(0, SlowlyCar.Length);
            GameObject randomCar = SlowlyCar[slowIndex];

            Instantiate(randomCar, randomPosition2.position, randomPosition2.rotation);

            yield return new WaitForSeconds(4f);
        }
    }

    // ���� ��� �� �޼��带 ���� RemoveItem ȣ�� ����
    public void DeactivateAndRemoveItems()
    {
        RemoveItem(); // �� ���� ȣ��
    }
}
