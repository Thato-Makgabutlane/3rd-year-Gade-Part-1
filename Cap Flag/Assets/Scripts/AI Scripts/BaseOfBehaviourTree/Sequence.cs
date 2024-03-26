using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class Sequence : Node
{
    protected List<Node> childrenList = new List<Node>();

    public Sequence(List<Node> childern)
    {
        
        this.childrenList = childern;
    }
    public override NodeState Evaluate()
    {
        bool isAnyChildRunning = false;
        foreach (Node child in childrenList)
        {
                
            if(child.Evaluate() == NodeState.Running)
            {
                isAnyChildRunning = true;
            }
            else if(child.Evaluate() == NodeState.Failure)
            {
                state = NodeState.Failure;
                return state;
            }
            else if (child.Evaluate() == NodeState.Success)
            {

            }
        }
        state = isAnyChildRunning ? NodeState.Running : NodeState.Success; //this is a fancy if statement
        return state;
    }
}



