using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CaptureFlag : Node
{
    [SerializeField] GameObject TargetFlag;
    NavMeshAgent enemyAgent;
    EnemyAI enemyAI;
    Animator animator;
    public CaptureFlag(GameObject targetFlag, NavMeshAgent agent, EnemyAI ai, Animator anim)
    {
        this.TargetFlag = targetFlag;
        this.enemyAgent = agent;
        this.enemyAI = ai;
        animator = anim;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(TargetFlag.transform.position, enemyAgent.transform.position);
        if (TargetFlag.CompareTag("Captured"))
        {
            enemyAgent.isStopped = true;
            GameManager.Instance.AiHasFlag();
            state = NodeState.Failure;//Forcing it to be Failure
        }
        else if(TargetFlag.CompareTag("Available") || TargetFlag.CompareTag("Down"))
        {
            enemyAgent.isStopped = false;
            enemyAgent.SetDestination(TargetFlag.transform.position);
            animator.Play("Running");
            state = NodeState.Running;
            Debug.Log("Success");
            if(distance <= 1)
            {
                TargetFlag.tag = "Captured";
                TargetFlag.transform.parent = enemyAgent.transform;
            }
        }
        else
        {
            state = NodeState.Failure;
        }

        return state;
    }
}

