using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Animations();
    }

    void Animations()
    {
        float x = animator.GetFloat("X");
        if (x < 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }
}
