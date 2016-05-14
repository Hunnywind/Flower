using UnityEngine;
using System.Collections;

public class GoatAnim : StateMachineBehaviour {

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Goat>().EatComplete = true;
    }
}
