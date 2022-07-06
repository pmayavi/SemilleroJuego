using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogBoss : MonoBehaviour
{
    public GameObject enemy;
    public GameObject healthBar;
    public Slider healthBarSlider;
    public GameObject proyectile;
    public float maxHealth;
    public float points;
    public float shootCooldown;
    public int bulletSize;
    public float force;
    public float damage;
    public float speed;

    private BoxCollider2D collide;
    private SpriteRenderer sprite;
    private GameObject playerObj;
    private Vector2 direction;
    private Animator animator;
    private GameObject me;
    private float health;
    private bool jumping;
    private bool shoot;
    private bool dead;

    void Start()
    {
        shoot = true;
        jumping = false;
        me = gameObject;
        dead = false;
        health = maxHealth;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collide = GetComponent<BoxCollider2D>();
        if (GetComponent<EnemyMelee>())
            GetComponent<EnemyMelee>().SetDamage(damage);
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        if (dead && animator.GetBool("death") == false)
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().Point(points);
            Destroy(gameObject);
        }
        if (jumping)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            if (
                transform.position.x > 62f
                || transform.position.x < -62f
                || transform.position.y > 12.5f
                || transform.position.y < -41f
            )
                Direction();
        }
        else
        {
            Direction();
            Move();
        }
    }

    public virtual void Direction()
    {
        if (playerObj)
        {
            Vector2 playerPos = playerObj.transform.position;
            Vector2 myPos = transform.position;
            direction = (playerPos - myPos).normalized;
        }
        else
            direction = Vector2.zero;
    }

    public void Move()
    {
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
        else
            Jump();
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

    void Jump()
    {
        animator.SetBool("jump", true);
        jumping = true;
        collide.enabled = false;
        sprite.sortingOrder = 31;
        Direction();
        direction = direction * -1;
        if (direction.x > 0)
            sprite.flipX = true;
        else if (direction.x < 0)
            sprite.flipX = false;
        Invoke("StopJump", 1.25f);
    }

    void StopJump()
    {
        animator.SetBool("jump", false);
        sprite.sortingOrder = 0;
        jumping = false;
        collide.enabled = true;
    }

    private void SliderPercentage()
    {
        healthBarSlider.value = (health / maxHealth);
    }
}
