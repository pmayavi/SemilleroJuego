using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogBoss : EnemyFollow
{
    public GameObject enemy;

    public GameObject healthBar;
    public Slider healthBarSlider;
    private bool dead;
    protected float health;
    public float maxHealth;
    public float points;
    public float damageFrog;
    private GameObject me;
    public GameObject proyectile;
    public float force;
    private bool shoot;
    public float shootCooldown;
    public int bulletSize;

    public override void Start()
    {
        damage = damageFrog;
        shoot = true;
        me = gameObject;
        dead = false;
        health = maxHealth;
        animator = GetComponent<Animator>();
        GetComponent<EnemyFollow>().SetDamage(damage);
        GetComponent<EnemyFollow>().SetSpeed(speed);
        if (GetComponent<EnemyMelee>())
            GetComponent<EnemyMelee>().SetDamage(damage);
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Move()
    {
        if (dead && animator.GetBool("death") == false)
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().Point(points);
            Destroy(gameObject);
        }
        if (playerObj && shoot)
        {
            shoot = false;
            animator.SetBool("shoot", true);
            Invoke("Shoot", 0.2f);
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(proyectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
        bullet.GetComponent<ProyectileScript>().dmg = damage;
        bullet.GetComponent<Transform>().localScale = new Vector3(bulletSize, bulletSize, 1);
        animator.SetBool("shoot", false);
        Invoke("Shoot2", shootCooldown - 0.2f);
    }

    public void Shoot2()
    {
        shoot = true;
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
