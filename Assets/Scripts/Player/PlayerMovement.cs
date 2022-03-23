using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            OnInput();
            Move();
        }
    }

    private void OnInput()
    {
        direction = Vector2.zero;
        int j = 0;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            j++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (j == 0)
            {
                direction += Vector2.left;
                j++;
            }
            else
            {
                j++;
                direction *= (1 - 1 / j);
                direction += (Vector2.left / j);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (j == 0)
            {
                direction += Vector2.down;
                j++;
            }
            else
            {
                j++;
                direction *= (1 - 1 / j);
                direction += (Vector2.down / j);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (j == 0)
            {
                direction += Vector2.right;
            }
            else
            {
                j++;
                direction *= (1 - 1 / j);
                direction += (Vector2.right / j);
            }
        }
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        Animations(direction);
    }

    private void Animations(Vector2 direction)
    {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }
}
