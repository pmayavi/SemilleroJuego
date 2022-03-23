using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusFather : MonoBehaviour
{
    public float number;
    public float coolDown;
    protected SpriteRenderer sprite;
    protected SpriteRenderer player;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (number < 1 && tag == "Buff")
        {
            sprite.color = new Color(120, 0, 0, 255);
            sprite.flipX = true;
        }
        else
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            StartCoroutine(Debuff());
            if (tag == "Buff")
                Destroy(gameObject);
        }
    }

    public virtual IEnumerator Debuff()
    {
        yield return new WaitForSeconds(coolDown);
    }
}
