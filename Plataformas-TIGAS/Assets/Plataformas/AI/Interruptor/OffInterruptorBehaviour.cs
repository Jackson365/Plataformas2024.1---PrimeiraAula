using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffInterruptorBehaviour : StateMachineBehaviour
{
    private InterruptorController _meuInterruptorController;
    
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _meuInterruptorController = animator.GetComponent<InterruptorController>();
        
        _meuInterruptorController.ChageColor(Color.red);
    }
}
