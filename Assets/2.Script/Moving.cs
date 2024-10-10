using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // �Է�
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        // ���� 
        Vector2 movement = new Vector2(X, Y).normalized;

        // �̵�.
        if (movement.magnitude >= 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}



