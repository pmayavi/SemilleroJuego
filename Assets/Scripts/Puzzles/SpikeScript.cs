using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public ButtonScript button;
    public float damage;

    void Update(){
        if(button.on){
            GetComponent<Animator>().SetBool("triggered", true);
        }
        else{
            GetComponent<Animator>().SetBool("triggered", false);
        }
    }
}
