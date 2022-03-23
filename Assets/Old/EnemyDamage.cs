using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float hp;
    public float max;
    private Animator animator;
    private bool dead;

    void Start()
    {
        hp = max;
        dead = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (dead && animator.GetBool("death") == false){
            Destroy(gameObject);
        }
    }

    public void Damage(float dmg){
        hp -= dmg;
        Death();
    }

    private void Death(){
        if(hp <= 0){
            animator.SetBool("death", true);
            dead = true;
        }
    }
}
