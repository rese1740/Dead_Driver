using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public static PoliceCar Instance;

    public Animator animator;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void CarAnim()
    {
        animator.SetTrigger("Dis");
    } 
}
