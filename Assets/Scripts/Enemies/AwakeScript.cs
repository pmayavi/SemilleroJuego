using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private EnemyFollow follow;
    private Animator animator;
    public Sprite headAwake;
    public Sprite headSleep;

    void Start()
    {
        follow = transform.parent.gameObject.GetComponent<EnemyFollow>();
        sprite = GetComponent<SpriteRenderer>();
        animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    void Update() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            sprite.sprite = headAwake;
            follow.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            sprite.sprite = headSleep;
            follow.enabled = false;
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", 0);
        }
    }
}
