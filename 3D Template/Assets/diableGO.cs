using UnityEngine;

public class diableGO : StateMachineBehaviour
{
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.transform.parent.gameObject);
    }
}
