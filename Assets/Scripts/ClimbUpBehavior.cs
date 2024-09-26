using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var player = GameObject.Find("Player").GetComponent<AnimationAndMovementController>();
        player.movementDisabled = true;
        //  player.gameObject.transform.position += player.gameObject.transform.forward * 1f;
        //  player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 1.7f, player.gameObject.transform.position.z);
        //  player.gameObject.SetActive(true);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machiwne finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       var player = GameObject.Find("Player").GetComponent<AnimationAndMovementController>();
       player.swimExitTriggered = false;
       player.swimTriggered = false;
       player.gameObject.SetActive(false);
       //player.gameObject.transform.position = player.GetStandUpPos(player._activeLedge);
       player.gameObject.transform.position += player.gameObject.transform.forward * 1f;
        player.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 1.7f, player.gameObject.transform.position.z);
       player.gameObject.SetActive(true);
        animator.SetBool("IsSwimming", false);
        animator.SetBool("IsSwimIdle", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", false);
        player.movementDisabled = false;
        //animator.SetBool("SwimExit", false);
       

    }

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
