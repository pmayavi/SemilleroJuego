using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.SetBool("death", false);
    }
}
