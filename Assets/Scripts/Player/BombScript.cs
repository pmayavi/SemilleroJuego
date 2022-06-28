using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Animator animator;
    public float fuse;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Explote());    
    }

    // Update is called once per frame
    public IEnumerator Explote()
    {
        yield return new WaitForSeconds(fuse);
        animator.SetBool("Explote", true);
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public float dmg;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyStats>() != null)
        {
            collision.GetComponent<EnemyStats>().Hurt(dmg);
        }
        else if (collision.GetComponent<PlayerMovement>() != null)
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().Hurt(dmg);
        }
        else if (collision.GetComponent<BurnScript>() != null)
        {
            collision.GetComponent<BurnScript>().Burn();
        }
        else if (collision.GetComponent<FrogBoss>() != null)
        {
            collision.GetComponent<FrogBoss>().Hurt(dmg);
        }
    }


}
