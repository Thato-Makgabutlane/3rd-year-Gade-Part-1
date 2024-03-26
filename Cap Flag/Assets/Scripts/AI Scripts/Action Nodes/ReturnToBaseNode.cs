using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnToBaseNode : Node
{
    [SerializeField] GameObject TargetFlag;
    GameObject Base;
    NavMeshAgent enemyAgent;
    EnemyAI enemyAI;
    Animator animator;

    public ReturnToBaseNode(GameObject targetFlag, GameObject @base, NavMeshAgent enemyAgent, EnemyAI enemyAI, Animator anim)
    {
        this.TargetFlag = targetFlag;
        this.Base = @base;
        this.enemyAgent = enemyAgent;
        this.enemyAI = enemyAI;
        animator = anim;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(Base.transform.position, enemyAgent.transform.position);
        if (TargetFlag.CompareTag("Captured"))
        {
            enemyAgent.isStopped = false;
            enemyAgent.SetDestination(Base.transform.position);
            animator.Play("Running");
            state = NodeState.Running;
            if (distance <= 1)
            {
                TargetFlag.tag = "Base";
            }
        }
        else if(TargetFlag.CompareTag("Dropped"))
        {
            state = NodeState.Failure;
        }
        else if(TargetFlag.CompareTag("Base"))
        {
            enemyAgent.isStopped = true;
            TargetFlag.transform.parent = null;
            state = NodeState.Success;
        }
        return state;
    }
}
