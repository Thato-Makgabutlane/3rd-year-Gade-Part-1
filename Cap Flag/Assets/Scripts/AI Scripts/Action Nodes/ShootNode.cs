using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootNode : Node
{
    GameObject Bullets;
    NavMeshAgent enemyAgent;
    GameObject Player;
    EnemyAI enemyAI;
    Animator animator;
    public ShootNode(NavMeshAgent agent, EnemyAI ai, GameObject player , Animator anim)
    {
        this.enemyAgent = agent;
        Player = player;
        this.enemyAI = ai;
        animator = anim;
    }
    public override NodeState Evaluate()
    {
        enemyAgent.isStopped = true;
        enemyAgent.gameObject.transform.LookAt(Player.transform);
        animator.Play("Gunplay");
        return NodeState.Running;//Executing the shoot thus running 

    }

}
