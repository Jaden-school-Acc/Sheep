using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskIdleBehaviour : StateMachineBehaviour
{

    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {

    //     RectTransform rectTransform = animator.transform.GetComponent<RectTransform>();

    //     switch(animator.GetInteger("lastAnim")){

    //         case 1:
    //             Debug.Log("success on 1. setting rect transform.position to 0,1080,0");
    //             rectTransform.anchoredPosition = new Vector3(0, 1080, 0);
    //             break;
    //         case -1:
    //             Debug.Log("success on -1. setting rect transform.position to 0,0,0");
    //             rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    //             break;
    //         default:
    //             Debug.Log($"lastAnim does not equal 1 or -1. It equals {animator.GetInteger("lastAnim")}");
    //             rectTransform.anchoredPosition = new Vector3(0, 1080, 0);
    //             break;
    //     }
    // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
