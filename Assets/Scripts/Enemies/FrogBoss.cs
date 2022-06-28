using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogBoss : MonoBehaviour
{
    public GameObject enemy;

    public GameObject healthBar;
    public Slider healthBarSlider;
    private Animator animator;
    private bool dead;
    protected float health;
    public float maxHealth;
    public float damage;
    public float speed;
    public float points;
    public GameObject me;

    void Start()
    {
        me = gameObject;
        dead = false;
        health = maxHealth;
        animator = GetComponent<Animator>();
        GetComponent<EnemyFollow>().SetDamage(damage);
        GetComponent<EnemyFollow>().SetSpeed(speed);
        if (GetComponent<EnemyMelee>())
            GetComponent<EnemyMelee>().SetDamage(damage);
    }

    void Update()
    {
        if (dead && animator.GetBool("death") == false)
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().Point(points);
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        animator.SetBool("shoot", false);
        if (health <= 0)
            Death();
    }

    public void Hurt(float dmg)
    {
        healthBar.SetActive(true);
        health -= dmg;
        animator.SetBool("Damage", true);
        Invoke("Damage", 0.25f);
        SliderPercentage();
    }

    public void Damage()
    {
        animator.SetBool("Damage", false);
        if (health <= 0)
            Death();
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        SliderPercentage();
    }

    void Death()
    {
        animator.SetBool("death", true);
        dead = true;
    }

    private void SliderPercentage()
    {
        healthBarSlider.value = (health / maxHealth);
    }
}
