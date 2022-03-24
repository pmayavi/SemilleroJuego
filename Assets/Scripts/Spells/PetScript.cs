using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    protected GameObject playerObj = null;
    protected Animator animator;
    protected Vector2 direction;
    public float speed;

    public virtual void Start()
    {
        if (GetComponent<Animator>())
            animator = GetComponent<Animator>();
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        Direction();
        Move();
    }

    public virtual void Direction()
    {
        if (playerObj)
        {
            Vector2 playerPos = playerObj.transform.position;
            Vector2 myPos = transform.position;
            if (Vector2.Distance(playerPos, myPos) > 1.5)
                direction = (playerPos - myPos).normalized;
            else direction = Vector2.zero;
        }
        else direction = Vector2.zero;
    }

    public virtual void Move()
    {
        Debug.Log(direction);
        transform.Translate(direction * speed * Time.deltaTime);
        Animations(direction);
    }

    private void Animations(Vector2 direction)
    {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }
}