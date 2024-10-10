using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float GelfSpeed = 500f;

    public float CrushCount = 50f;

    public GameObject RedPanel;




    private void Start()
    {
        RedPanel.SetActive(true);

        Invoke("RedPanelDown", 1f);
        Invoke("CarDestroy", 4f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime *GelfSpeed;
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerUI.Instance.PlayerHp -= CrushCount;
        CameraShake.Instance.CameraShaking();
    }

    void RedPanelDown()
    {
        RedPanel.SetActive(false);
    }

    void CarDestroy()
    {
        Destroy(gameObject);
    }




}
