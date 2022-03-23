using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnScript : MonoBehaviour
{
    public GameObject fire;
    public float duration;

    private Animator animator;
    private GameObject entity;
    private float time;
    private bool burning;

    public virtual void Start()
    {
        time = duration;
        burning = false;
        animator = GetComponent<Animator>();
    }

    public virtual void Burn()
    {
        if (!burning){
            burning = true;
            entity = Instantiate(fire, transform.position, Quaternion.identity);
            Invoke("Death", duration);
        }
    }

    public void Death(){
        Destroy(gameObject);
        Destroy(entity);
    }
}
