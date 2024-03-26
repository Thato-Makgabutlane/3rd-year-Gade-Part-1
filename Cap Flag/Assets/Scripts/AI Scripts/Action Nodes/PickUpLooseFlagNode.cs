using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpLooseFlagNode : Node
{
    Transform targetPos;
    GameObject OwnFlagSpawnPoint;
    NavMeshAgent enemyAgent;
    EnemyAI enemyAI;
    Animator animator;

    public PickUpLooseFlagNode(Transform target, NavMeshAgent enemy, EnemyAI ai, GameObject ownFlagSpawnPoint, Animator anim)
    {
        this.targetPos = target;
        this.enemyAgent = enemy;
        this.enemyAI = ai;
        this.OwnFlagSpawnPoint = ownFlagSpawnPoint;
        animator = anim;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(targetPos.position, enemyAgent.transform.position);

        if (distance > 2f)
        {
            enemyAgent.isStopped = false;
            enemyAgent.SetDestination(targetPos.position);
            animator.Play("Running");
            state = NodeState.Running;
        }
        else
        {
            enemyAgent.isStopped = true;
            targetPos.gameObject.transform.position = OwnFlagSpawnPoint.transform.position;
            targetPos.gameObject.tag = "Safe";
            state = NodeState.Success;
        }
        return state;
    }

}
