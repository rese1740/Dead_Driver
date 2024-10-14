using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static Car Instance;
    public GameObject RedPanel;

    private void Start()
    {
        Invoke("RedPanelDown", 1f);
        Invoke("LaserDestroy", 3f);
    }

    void RedPanelDown()
    {
        RedPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void LaserDestroy()
    {
        Destroy(gameObject);
    }
}
