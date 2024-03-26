using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LooseFlagNode : Node
{
    [SerializeField] GameObject TargetFlag;
    NavMeshAgent enemyAgent;
    EnemyAI enemyAI;
    public LooseFlagNode(GameObject targetFlag, NavMeshAgent agent, EnemyAI ai)
    {
        this.TargetFlag = targetFlag;
        this.enemyAI = ai;
        this.enemyAgent = agent;
    }

    public override NodeState Evaluate()
    {
        if (TargetFlag.CompareTag("Dropped"))
        {
            state = NodeState.Success;
        }
        else
        {
            state = NodeState.Failure;
        }
        return state;
    }
}
