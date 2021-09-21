using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
	public GameObject MechSkill1;
	
	public GameObject MechSkill2;
	public GameObject DeploySkill2;
	
	private float timeBack;
	private bool activeMech2 = false;
	private bool activeBlood = false;
	Transform player;
	
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBack = 3;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		/*
		//HP BOSS >50
        if (timeBack > 4){
			animator.SetTrigger("Attack");
			GameObject a = Instantiate(MechSkill1) as GameObject;
			
			timeBack = 0;
		}
		*/
		
		//HP BOSS <=50
		if (timeBack > 4 && activeMech2 == false){
			animator.SetTrigger("Attack");
			GameObject a = Instantiate(MechSkill2) as GameObject;
			activeMech2 = true;
			timeBack = 0;
		}
		if (timeBack > 0.3 && activeMech2 == true && activeBlood == false){
			animator.SetTrigger("Attack");
			//cast Mech skill 2
			GameObject deploy1 = Instantiate(DeploySkill2) as GameObject;
			activeBlood = true;
		}
		if (timeBack > 0.7 && activeMech2 == true ){
			animator.SetTrigger("Attack");
			//cast Mech skill 2
			GameObject deploy1 = Instantiate(DeploySkill2) as GameObject;
			activeBlood = false;
			timeBack = 0;
		}
		
		timeBack = timeBack + Time.fixedDeltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		animator.ResetTrigger("Attack");
    }

  
}
