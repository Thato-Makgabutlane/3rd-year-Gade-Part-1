using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject targetFlag;
    [SerializeField] GameObject ProtectFlag;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject OwnFlagSpawnPoint;
    [SerializeField] GameObject Base;
    [SerializeField] Animator animator;
    NavMeshAgent agent;
    Node topNode;
    Pistol dummy;
    Pistol Real;
    [SerializeField] float range;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Real = GetComponent<Pistol>();
    }

    void Start()
    {
        ConstructTree();
    }

    void Update()
    {
        topNode.Evaluate();
    }

    void ConstructTree()
    {
        //All Custom Nodes
        ReturnToBaseNode BackToBase = new ReturnToBaseNode(targetFlag, Base, agent, this, animator);
        LooseFlagNode LooseFlag = new LooseFlagNode(ProtectFlag, agent, this);
        PickUpLooseFlagNode PickUpLooseFlag = new PickUpLooseFlagNode(ProtectFlag.transform,agent, this,OwnFlagSpawnPoint, animator);
        RangeNode LooseFlagRang = new RangeNode(range, ProtectFlag.transform, this.transform,dummy);
        RangeNode ShootRange = new RangeNode(range, Player.transform, this.transform,Real);
        ShootNode shootNode = new ShootNode(agent, this, Player, animator);
        CaptureFlag CaptureFlagNode = new CaptureFlag(targetFlag,agent, this, animator);

        //All Sequences and Selectors
        Sequence LooseFlagSequence = new Sequence(new List<Node> { LooseFlagRang, LooseFlag, PickUpLooseFlag });
        Sequence ShootSequence = new Sequence(new List<Node> { ShootRange, shootNode });
        Sequence PickUpSequence = new Sequence(new List<Node> { LooseFlagSequence, ShootSequence });
        Selector BackToBaseSelector = new Selector(new List<Node> { LooseFlagSequence, BackToBase });
        Sequence CaptureFlagSequence = new Sequence(new List<Node> { CaptureFlagNode , ShootSequence });

        //Top Node
        topNode = new Selector(new List<Node> { CaptureFlagSequence, ShootSequence, PickUpSequence, BackToBaseSelector });
        Debug.Log("Tree Done");
    }

}
