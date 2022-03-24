using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : StateMachineBehaviour
{
    public bool damage;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CapsuleCollider2D>().enabled = damage;
    }
}
