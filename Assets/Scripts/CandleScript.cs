using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            animator.SetBool("On", true);
            transform.parent.gameObject.GetComponent<SummonScript>().Light();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
