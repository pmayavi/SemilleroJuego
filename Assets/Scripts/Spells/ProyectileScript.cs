using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour
{
    public float dmg;
    public string self;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != self)
        {
            if (collision.GetComponent<EnemyStats>() != null)
            {
                collision.GetComponent<EnemyStats>().Hurt(dmg);
            }
            if (collision.GetComponent<PlayerMovement>() != null)
            {
                GameObject.Find("GameManager").GetComponent<PlayerStats>().Hurt(dmg);
            }
            if (collision.GetComponent<BurnScript>() != null)
            {
                collision.GetComponent<BurnScript>().Burn();
            }
            else if (collision.GetComponent<FrogBoss>() != null)
            {
                collision.GetComponent<FrogBoss>().Hurt(dmg);
            }
            Destroy(gameObject);
        }
    }
}
