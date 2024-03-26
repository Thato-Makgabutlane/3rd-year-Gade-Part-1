using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : Node
{
    float range;
    Pistol scripts;
    Transform targetPos;
    Transform aiPos;

    public RangeNode(float _range, Transform target, Transform Aipos, Pistol script)
    {
        this.range = _range;
        this.targetPos = target;
        this.aiPos = Aipos;
        if(script != null)
        {
            scripts = script;
        }
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(targetPos.position, aiPos.position);

        if (distance <= range)
        {
            if (scripts != null)
            {
                scripts.enabled = true;
            }
            return NodeState.Success;
        }
        else
        {
            if (scripts != null)
            {
                scripts.enabled = false;
            }
            return NodeState.Failure;
        }
    }

}
